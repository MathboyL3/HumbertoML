using HumbertoML.ActivationFunctions;
using HumbertoML.Interfaces;
using HumbertoML.NeuralNets;
using HumbertoML.Training;
using HumbertoML.Utility;
using HumbertoML.WeightsInitializers;
namespace HumbertoML.Visualize
{
    public partial class Form1 : Form
    {
        private bool _shouldStopTrainning = false;
        private bool _isTrainningRunning = false;

        private bool _useCos = false;
        private bool _useSin = false;
        private bool _useAtan2 = false;
        private int _maxTotalIterations = 100_000;
        private int _updateAfterIterations = 10;
        private int _totalTrainedIteration = 0;
        private float _errorThreshold = 0.02f;

        private float _learningRate = 0.05f;

        private IActivationDeactiviationFunction _activationFunction;
        private Dictionary<string, IActivationDeactiviationFunction> _possibleActivationFunction;

        private IWeightInitializer _weightsInitializer;
        private Dictionary<string, IWeightInitializer> _possibleWeightsInitializers;

        private int[] _config;

        private List<Control> _nudsLayerConfig;
        private List<(CheckBox ch, Color paintColor, Color lighterColor)> _paintMappingConfig;
        private Dictionary<Color, List<Point>> _dataPoints;

        // Cores e mapeamentos referentes aos pontos que são desenhados na tela
        private Color[] _lighterColors => _dataPoints.Keys.Select(x => _paintMappingConfig.FirstOrDefault(y => y.paintColor.Equals(x)).lighterColor).ToArray();
        private Color? _selectedColor = null;
        private Color[] _allColors => _dataPoints.Keys.ToArray();

        private Pen _pen = new Pen(Color.Gray, 1);
        private Image _ballImage = Image.FromFile(@"C:\Users\Daniel Curi\Pictures\HumbertoML.Visualize\Neuron.png");

        private FeedForwardNet _nn;
        private bool _isNNInvalid = true; // Se a nn atual está invalidada por mudanças na configuração dela

        private float _nnPredictionImageScale = 0.3f;

        // for NN visualization
        private List<Point[]> _neuronConnections = new(); // only visuals

        private List<PictureBox> _neuronAvailablePool; // only visuals
        private List<PictureBox> _neuronUsingPool; // only visuals

        public Form1()
        {
            InitializeComponent();

            _dataPoints = new();

            _activationFunction = Functions.Sigmoid;

            _possibleActivationFunction = new()
            {
                ["Sigmoid"] = Functions.Sigmoid,
                ["TanH"] = Functions.Tanh,
                ["ReLU"] = Functions.ReLU,
                ["LeakyReLU"] = Functions.LeakyReLU,
                ["SoftPlus"] = Functions.SoftPlus,
                ["Linear"] = Functions.Linear,
            };

            _weightsInitializer = WInitializers.WIXavierUniform;

            _possibleWeightsInitializers = new()
            {
                ["Xavier (Normal)"] = WInitializers.WIXavierNormal,
                ["Xavier (Uniform)"] = WInitializers.WIXavierUniform,
                ["Kaiming (Normal)"] = WInitializers.WIKaimingNormal,
                ["Kaiming (Uniform)"] = WInitializers.WIKaimingUniform,
                ["Gaussian (m 0, sdtDev 1)"] = WInitializers.WIGaussianDistributed,
                ["Random (0 to 1)"] = WInitializers.WIPositiveRandom01,
                ["Random (-1 to 1)"] = WInitializers.WINPRandom11,
                ["Random (0 to 5)"] = WInitializers.WIPositiveRandom05,
                ["Random (-5 to 5)"] = WInitializers.WINPRandom55,
            };

            _nudsLayerConfig =
            [
                nud_layer1,
                nud_layer2,
                nud_layer3,
                nud_layer4,
                nud_layer5,
                nud_layer6,
                nud_layer7,
                nud_layer8,
                nud_layer9,
                nud_layer10,
                nud_layer11,
                nud_layer12,
            ];

            var blue = Color.FromArgb(0, 8, 255);
            var cyan = Color.FromArgb(0, 255, 255);
            var green = Color.FromArgb(0, 255, 0);
            var yellow = Color.FromArgb(255, 255, 0);
            var orange = Color.FromArgb(255, 134, 0);
            var red = Color.FromArgb(255, 0, 0);
            var pink = Color.FromArgb(255, 0, 255);
            var purple = Color.FromArgb(122, 0, 255);

            _paintMappingConfig =
            [
                (ch_red, red, MakeLighterColor(red)),
                (ch_blue, blue, MakeLighterColor(blue)),
                (ch_cyan, cyan, MakeLighterColor(cyan)),
                (ch_yellow, yellow, MakeLighterColor(yellow)),
                (ch_green, green, MakeLighterColor(green)),
                (ch_orange, orange, MakeLighterColor(orange)),
                (ch_pink, pink, MakeLighterColor(pink)),
                (ch_purple, purple, MakeLighterColor(purple)),
            ];
        }


        private void SetErrorText(float error)
        {
            label_Error.Invoke(delegate { label_Error.Text = $"Error {error.ToString("N2")}"; });
        }
        private void SetIterationText(int it)
        {
            label_Iteration.Invoke(delegate { label_Iteration.Text = $"Iteration {it}"; });
        }
        private void ResetInfoText()
        {
            label_Error.Text = "Error 0";
            SetIterationText(0);
        }


        private bool ShowError()
        {
            if (_dataPoints.Keys.Count < 1)
            {
                MessageBox.Show("Use as cores para adicionar pontos ao gráfico", "Erro");
                return true;
            }

            return false;
        }


        private void InvalidateNN()
        {
            _isNNInvalid = true;
        }
        private void CreateNewValidNN()
        {
            ResetText();
            UpdateConfigParameters();
            var acFunction = Activator.CreateInstance(_activationFunction.GetType());
            var wInit = Activator.CreateInstance(_weightsInitializer.GetType());
            _nn = new FeedForwardNet(_config, (IActivationDeactiviationFunction)acFunction, ActivationFunctions.Functions.SoftMax, (IWeightInitializer)wInit);
            _isNNInvalid = false;
            _totalTrainedIteration = 0;
            _shouldStopTrainning = false;
        }


        private void UpdateClassificationGraph()
        {
            int height = (int)(panel_graph.Height * _nnPredictionImageScale);
            int width = (int)(panel_graph.Width * _nnPredictionImageScale);

            var img = new Bitmap(width, height);
            var colors = this._lighterColors;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var data = GetDataFromPoint(new Point(x, y), _nnPredictionImageScale);
                    var result = _nn.Feed(data);
                    var pos = result.Maximize().IndexOf(1);
                    img.SetPixel(x, y, colors[pos]);
                }
            }
            var old = panel_graph.BackgroundImage;
            panel_graph.BackgroundImage = img;
            old?.Dispose();

        }
        private void UpdateConfigVisuals()
        {
            _neuronConnections = new();
            UpdateConfigParameters();

            if (_config is null) return;

            foreach (var c in panel_redeNeuralVisuals.Controls)
                RemoveFromPool((PictureBox)c);

            panel_redeNeuralVisuals.Controls.Clear();

            var paddingHeight = 0.05f;
            var paddingWidth = 0.05f;

            var height = panel_redeNeuralVisuals.Height - (panel_redeNeuralVisuals.Height * paddingHeight);
            var width = panel_redeNeuralVisuals.Width - (panel_redeNeuralVisuals.Width * paddingWidth);

            int maxLayerSize = _config.Max();
            int layerCount = _config.Length;

            var neuronHeight = height / maxLayerSize + 1;
            var neuronWidth = width / layerCount + 1;

            var midW = width / (layerCount + 1);
            var maxMidW = midW * 0.9f;
            var maxMidH = height / (maxLayerSize + 1) * 0.9f;

            int size = (int)Math.Min(maxMidW, Math.Min(maxMidH, Math.Max(1, Math.Min(neuronHeight, neuronWidth))));
            int haflSize = (size / 2);
            (float X, float Y) startPos = (panel_redeNeuralVisuals.Height * paddingHeight / 2f, panel_redeNeuralVisuals.Width * paddingWidth / 2f);
            var neuronSize = new Size(size, size);

            var colors = this._allColors;
            for (int i = 0; i < layerCount; i++)
            {
                _neuronConnections.Add(new Point[_config[i]]);

                var midH = height / (_config[i] + 1);
                var pos = new Point();
                pos.X = (int)(startPos.X - haflSize + midW * (i + 1));

                for (int k = 0; k < _config[i]; k++)
                {
                    pos.Y = (int)(startPos.Y - haflSize + midH * (k + 1));

                    if (i == layerCount - 1 && colors.Length > 0)
                    {
                        CreateAt(neuronSize, pos, $"l{i}n{k}", colors[k]);
                    }
                    else
                    {
                        CreateAt(neuronSize, pos, $"l{i}n{k}");
                    }

                    _neuronConnections[i][k] = new Point(pos.X + haflSize, pos.Y + haflSize);
                }
            }
            panel_redeNeuralVisuals.Invalidate();
        }

        private void ClearGraph()
        {
            foreach (var c in _paintMappingConfig)
                c.ch.Checked = false;
            _selectedColor = null;

            foreach (var c in panel_graph.Controls)
                ((Control)c).Dispose();

            panel_graph.Controls.Clear();
            panel_graph.BackgroundImage?.Dispose();
            panel_graph.BackgroundImage = null;
            panel_graph.BackColor = Color.White;
            _dataPoints = new();

            InvalidateNN();
            ActivateStart();
            UpdateConfigVisuals();
            ResetInfoText();
        }

        private void CreateAt(Size size, Point location, string name, Color? color = null)
        {
            var neuron = GetFromPool();
            neuron.BackgroundImage?.Dispose();
            neuron.BackgroundImage = null;
            var img = new Bitmap(this._ballImage);
            if (color is not null)
                ChangeImageBaseColor(img, color.Value);
            neuron.BackgroundImage = img;
            neuron.BackColor = Color.Transparent;
            neuron.BackgroundImageLayout = ImageLayout.Stretch;
            neuron.Location = location;
            neuron.Name = name;
            neuron.Size = size;
            neuron.TabIndex = 0;
            neuron.TabStop = false;
            panel_redeNeuralVisuals.Controls.Add(neuron);
        }
        private PictureBox GetFromPool()
        {
            _neuronAvailablePool ??= new List<PictureBox>();
            _neuronUsingPool ??= new List<PictureBox>();
            PictureBox pc = null;

            if (_neuronAvailablePool.Count > 0)
            {
                pc = _neuronAvailablePool[0];
                _neuronAvailablePool.RemoveAt(0);
            }
            pc ??= new PictureBox();
            _neuronUsingPool.Add(pc);
            return pc;
        }
        private void RemoveFromPool(PictureBox p)
        {
            _neuronAvailablePool ??= new List<PictureBox>();
            _neuronUsingPool ??= new List<PictureBox>();

            _neuronAvailablePool.Add(p);
            _neuronUsingPool.Remove(p);
        }

        void CreatePointAt(Color color, Point location, Size size)
        {
            var point = new PictureBox();
            var newImg = new Bitmap(_ballImage);
            ChangeImageBaseColor(newImg, color);
            point.BackgroundImage = newImg;
            point.BackColor = Color.Transparent;
            point.BackgroundImageLayout = ImageLayout.Stretch;
            point.Location = location;
            point.Name = $"{color.A}&{color.R}&{color.G}&{color.B}";
            point.Size = size;
            point.TabIndex = 0;
            point.TabStop = false;
            point.Click += OnPointDelete_Click;
            panel_graph.Controls.Add(point);
        }



        private bool ResultEqualsAnswer(float[] a, float[] b)
        {
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i])
                    return false;

            return true;
        }
        private float[] GetDataFromPoint(Point point, float factor)
        {
            float height = panel_graph.Height * factor;
            float width = panel_graph.Width * factor;

            List<float> result = new()
            {
                point.X / width,
                point.Y / height,
            };

            if (_useCos)
            {
                result.Add(MathF.Cos(point.X) / width);
                result.Add(MathF.Cos(point.Y) / height);
            }

            if (_useSin)
            {
                result.Add(MathF.Sin(point.X) / width);
                result.Add(MathF.Sin(point.Y) / height);
            }

            if (_useAtan2)
            {
                result.Add(MathF.Atan2(point.X, point.Y) / (width + height));
            }

            return result.ToArray();
        }
        private void ChangeImageBaseColor(Bitmap map, Color baseColor)
        {
            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    var pixel = map.GetPixel(x, y);
                    var r = (byte)(pixel.R * (baseColor.R / 255f));
                    var g = (byte)(pixel.G * (baseColor.G / 255f));
                    var b = (byte)(pixel.B * (baseColor.B / 255f));
                    map.SetPixel(x, y, Color.FromArgb(pixel.A, r, g, b));
                }
            }
        }
        private Color MakeLighterColor(Color color)
        {

            //return Color.FromArgb(128, color);

            var bright = 0.7f;

            var r = (int)Math.Min(color.R + ((255 - color.R) * bright), 255);
            var g = (int)Math.Min(color.G + ((255 - color.G) * bright), 255);
            var b = (int)Math.Min(color.B + ((255 - color.B) * bright), 255);

            return Color.FromArgb(255, r, g, b);
        }
        private float GetDistance(Point a, Point b)
        {
            var dX = b.X - a.X;
            var dY = b.Y - a.Y;
            return dX * dX + dY * dY;
        }

        private TrainingSet[] GetTrainingSet()
        {
            List<TrainingSet> set = new();

            float height = panel_graph.Height;
            float width = panel_graph.Width;

            var colors = this._allColors;

            for (int i = 0; i < colors.Length; i++)
            {
                var k = colors[i];
                var data = _dataPoints[k].Select(x => GetDataFromPoint(x, 1)).ToArray();
                var labels = new float[colors.Length];
                labels[i] = 1;
                set.Add(new TrainingSet(data, labels));
            }
            return set.ToArray();
        }
        private float GetNNError()
        {
            if (_nn is null || _isNNInvalid) return 1;

            var set = GetTrainingSet();
            float erros = 0;
            float total = 0;

            foreach (var s in set)
            {
                var answer = s.Label;
                foreach (var data in s.Set)
                {
                    var result = _nn.Feed(data).Maximize();
                    total++;
                    if (!ResultEqualsAnswer(result, answer))
                        erros++;
                }
            }
            return erros / total;
        }
        private void UpdateConfigParameters()
        {
            UpdateLastNumericValue();
            _config = new int[_nudsLayerConfig.Count(x => x.Visible)];
            for (int i = 0; i < _config.Length; i++)
                _config[i] = (int)((NumericUpDown)_nudsLayerConfig[i]).Value;
        }
        private void UpdateLastNumericValue()
        {
            var last = _nudsLayerConfig.Where(x => x.Visible).Cast<NumericUpDown>().LastOrDefault();
            SetNumericUpDownValue(last, Math.Max(1, _dataPoints.Count));
        }
        private void SetNumericUpDownValue(NumericUpDown nud, int value)
        {
            nud.ValueChanged -= OnLayerConfig_Changed;
            nud.Value = value;
            nud.ValueChanged += OnLayerConfig_Changed;
        }


        private void ActivateStart()
        {
            this.Invoke(delegate
            {
                btn_StartTrain.Enabled = true;
                btn_StopTrain.Enabled = false;
            });
        }
        private void ActivateStop()
        {
            this.Invoke(delegate
            {
                btn_StartTrain.Enabled = false;
                btn_StopTrain.Enabled = true;
            });
        }


        #region Events

        private void OnForm_Load(object sender, EventArgs e)
        {
            cb_functions.Items.Clear();

            foreach (var val in _possibleActivationFunction)
                cb_functions.Items.Add(val.Key);

            cb_functions.SelectedIndex = 0;

            cb_weights.Items.Clear();

            foreach (var val in _possibleWeightsInitializers)
                cb_weights.Items.Add(val.Key);

            cb_weights.SelectedIndex = 0;

            InvalidateNN();
            UpdateConfigVisuals();
            ClearGraph();
        }


        private void OnPointAddPanel_Click(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (_selectedColor is null) return;

            int size = 15;

            var point = new Point(e.X, e.Y);

            var color = _selectedColor.Value;

            if (_dataPoints.TryAdd(color, new()))
            {
                _dataPoints[color].Add(point);
                InvalidateNN();
                UpdateConfigVisuals();
            }
            else
            {
                _dataPoints[color].Add(point);
            }

            CreatePointAt(_selectedColor.Value, new Point((int)(point.X - size / 2f), (int)(point.Y - size / 2f)), new Size(size, size));
        }
        private void OnColorPicker_Changed(object sender, EventArgs e)
        {
            var ch = (CheckBox)sender;
            if (!ch.Checked)
            {
                _selectedColor = null;
                return;
            }
            else
            {
                foreach (var c in _paintMappingConfig)
                {
                    if (c.ch == ch) continue;
                    c.ch.Checked = false;
                }
            }

            _selectedColor = _paintMappingConfig.FirstOrDefault(x => x.ch == ch).paintColor;
        }
        private void OnPointDelete_Click(object sender, EventArgs e)
        {
            var ev = (MouseEventArgs)e;

            if (ev.Button != MouseButtons.Right) return;

            PictureBox p = (PictureBox)sender;

            byte[] colorData = p.Name.Split('&').Select(x => byte.Parse(x)).ToArray();
            var color = Color.FromArgb(colorData[0], colorData[1], colorData[2], colorData[3]);
            var loc = p.Location;
            var size = p.Size.Height;
            var point = new Point((int)(loc.X + size / 2f), (int)(loc.Y + size / 2f));
            if (!_dataPoints.TryGetValue(color, out var keys)) return;

            var toRemove = keys.OrderBy(x => GetDistance(x, point)).FirstOrDefault();

            if (GetDistance(toRemove, point) <= size / 2f)
                keys.Remove(toRemove);

            p.Dispose();

            if (keys.Count < 1)
            {
                _dataPoints.Remove(color);
                InvalidateNN();
                UpdateConfigVisuals();
            }
        }
        private void OnClearGraph_Click(object sender, EventArgs e)
        {
            _shouldStopTrainning = true;
            ClearGraph();
        }


        private void OnRemoveLayer_Click(object sender, EventArgs e)
        {
            for (int i = _nudsLayerConfig.Count - 1; i >= 0; i--)
            {
                if (i < 2) continue;
                var layer = _nudsLayerConfig[i];
                if (!layer.Visible) continue;

                if (i > 1)
                {
                    var currentL = (NumericUpDown)_nudsLayerConfig[i - 1];
                    currentL.Enabled = false;
                    SetNumericUpDownValue(currentL, Math.Max(1, _dataPoints.Count));
                }

                layer.Enabled = true;
                layer.Visible = false;
                InvalidateNN();
                UpdateConfigVisuals();
                break;
            }
        }
        private void OnAddLayer_Click(object sender, EventArgs e)
        {
            NumericUpDown val = (NumericUpDown)_nudsLayerConfig.FirstOrDefault();
            for (int i = 0; i < _nudsLayerConfig.Count; i++)
            {
                var layer = (NumericUpDown)_nudsLayerConfig[i];
                if (layer.Visible)
                {
                    val = layer;
                    continue;
                }

                if (i > 1)
                {
                    val.Enabled = true;
                    SetNumericUpDownValue(val, 1);
                }

                SetNumericUpDownValue(layer, Math.Max(1, _dataPoints.Count));
                layer.Visible = true;
                layer.Enabled = false;
                InvalidateNN();
                UpdateConfigVisuals();
                break;
            }
        }
        private void OnLayerConfig_Changed(object sender, EventArgs e)
        {
            InvalidateNN();
            UpdateConfigVisuals();
        }


        private void OnStartTraining_Click(object sender, EventArgs e)
        {
            if (ShowError())
                return;

            if (_isTrainningRunning) return;
            _isTrainningRunning = true;
            ActivateStop();
            try
            {
                _shouldStopTrainning = false;
                if (_isNNInvalid)
                {
                    CreateNewValidNN();
                    UpdateClassificationGraph();
                }
                var set = GetTrainingSet();

                _ = Task.Run(() =>
                {
                    var lr = _learningRate;
                    try
                    {
                        for (int i = 0; _totalTrainedIteration <= _maxTotalIterations; i += _updateAfterIterations)
                        {
                            if (_shouldStopTrainning)
                                break;

                            _nn.TrainCompleteData(set, _updateAfterIterations, lr);
                            _totalTrainedIteration += _updateAfterIterations;
                            var error = GetNNError();
                            SetErrorText(error);
                            SetIterationText(_totalTrainedIteration);
                            UpdateClassificationGraph();

                            if (error <= _errorThreshold)
                                break;
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    _isTrainningRunning = false;
                    ActivateStart();

                });
            }
            catch
            {
                _isTrainningRunning = false;
                ActivateStart();
                throw;

            }

        }
        private void OnStopTrainin_Click(object sender, EventArgs e)
        {
            _shouldStopTrainning = true;
            btn_StopTrain.Enabled = false;
        }


        private void NeuralNetVisual_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            for (int i = 0; i < _neuronConnections.Count - 1; i++)
            {
                for (int k = 0; k < _neuronConnections[i].Length; k++)
                {
                    var fromPos = _neuronConnections[i][k];
                    for (int o = 0; o < _neuronConnections[i + 1].Length; o++)
                    {
                        var toPos = _neuronConnections[i + 1][o];
                        e.Graphics.DrawLine(_pen, fromPos, toPos);
                    }
                }
            }

        }

        private void OnResetNN_Click(object sender, EventArgs e)
        {
            if (ShowError())
                return;

            Invalidate();
            CreateNewValidNN();
        }

        private void OnUpdateAfterIterations_Changed(object sender, EventArgs e)
        {
            _updateAfterIterations = (int)((NumericUpDown)sender).Value;
        }
        private void OnErrorThreashold_Changed(object sender, EventArgs e)
        {
            _errorThreshold = (float)((NumericUpDown)sender).Value;
        }
        private void OnMaxTotalIterations_Changed(object sender, EventArgs e)
        {
            _maxTotalIterations = (int)((NumericUpDown)sender).Value;
        }
        private void OnUseCos_Changed(object sender, EventArgs e)
        {
            _useCos = ((CheckBox)sender).Checked;
            var inputSize = GetDataFromPoint(new Point(1, 1), 1).Length;
            InvalidateNN();
            nud_layer1.Value = inputSize;
        }
        private void OnUseSin_Changed(object sender, EventArgs e)
        {
            _useSin = ((CheckBox)sender).Checked;
            var inputSize = GetDataFromPoint(new Point(1, 1), 1).Length;
            InvalidateNN();
            nud_layer1.Value = inputSize;
        }
        private void OnUseAtan2_Changed(object sender, EventArgs e)
        {
            _useAtan2 = ((CheckBox)sender).Checked;
            var inputSize = GetDataFromPoint(new Point(1, 1), 1).Length;
            InvalidateNN();
            nud_layer1.Value = inputSize;
        }
        private void OnLearningRate_Changed(object sender, EventArgs e)
        {
            _learningRate = (float)((NumericUpDown)sender).Value;
            InvalidateNN();
        }

        #endregion Events

        private void OnActivationFunction_Changed(object sender, EventArgs e)
        {
            _activationFunction = _possibleActivationFunction[((ComboBox)sender).SelectedItem.ToString()];
            InvalidateNN();
        }

        private void OnWeightsInitializer_Changed(object sender, EventArgs e)
        {
            _weightsInitializer = _possibleWeightsInitializers[((ComboBox)sender).SelectedItem.ToString()];
            InvalidateNN();
        }
    }
}
