namespace HumbertoML.Visualize
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            toolTip1 = new ToolTip(components);
            nud_updateRate = new NumericUpDown();
            nud_maxIterations = new NumericUpDown();
            nud_minError = new NumericUpDown();
            btn_clearGraph = new FontAwesome.Sharp.IconButton();
            btn_resetNN = new FontAwesome.Sharp.IconButton();
            panel_redeNeuralVisuals = new DoubleBufferedPanel();
            panel_graph = new DoubleBufferedPanel();
            btn_addLayer = new Button();
            btn_removeLayer = new Button();
            nud_layer12 = new NumericUpDown();
            nud_layer11 = new NumericUpDown();
            nud_layer10 = new NumericUpDown();
            nud_layer9 = new NumericUpDown();
            nud_layer8 = new NumericUpDown();
            nud_layer7 = new NumericUpDown();
            nud_layer6 = new NumericUpDown();
            nud_layer5 = new NumericUpDown();
            nud_layer4 = new NumericUpDown();
            nud_layer3 = new NumericUpDown();
            nud_layer2 = new NumericUpDown();
            nud_layer1 = new NumericUpDown();
            CamadasGroup = new GroupBox();
            ch_red = new CheckBox();
            ch_orange = new CheckBox();
            ch_yellow = new CheckBox();
            ch_green = new CheckBox();
            ch_cyan = new CheckBox();
            ch_blue = new CheckBox();
            ch_pink = new CheckBox();
            ch_purple = new CheckBox();
            checkBox9 = new CheckBox();
            checkBox10 = new CheckBox();
            checkBox11 = new CheckBox();
            checkBox12 = new CheckBox();
            checkBox13 = new CheckBox();
            checkBox14 = new CheckBox();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            btn_StartTrain = new Button();
            label_Error = new Label();
            label_Iteration = new Label();
            label1 = new Label();
            btn_StopTrain = new Button();
            label2 = new Label();
            label3 = new Label();
            ch_useCos = new CheckBox();
            ch_useAtan2 = new CheckBox();
            ch_useSin = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nud_updateRate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_maxIterations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_minError).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer12).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer11).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer9).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer8).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer1).BeginInit();
            CamadasGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // nud_updateRate
            // 
            nud_updateRate.Location = new Point(1277, 685);
            nud_updateRate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            nud_updateRate.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_updateRate.Name = "nud_updateRate";
            nud_updateRate.Size = new Size(88, 27);
            nud_updateRate.TabIndex = 10;
            toolTip1.SetToolTip(nud_updateRate, "A cada quantas iterações de treino o gráfico atualiza");
            nud_updateRate.Value = new decimal(new int[] { 10, 0, 0, 0 });
            nud_updateRate.ValueChanged += OnUpdateAfterIterations_Changed;
            // 
            // nud_maxIterations
            // 
            nud_maxIterations.Location = new Point(114, 712);
            nud_maxIterations.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            nud_maxIterations.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            nud_maxIterations.Name = "nud_maxIterations";
            nud_maxIterations.Size = new Size(88, 27);
            nud_maxIterations.TabIndex = 10;
            toolTip1.SetToolTip(nud_maxIterations, "A quantidade máxima que a AI vai treinar por todos os pontos antes de parar ou antingir o erro mínimo.");
            nud_maxIterations.Value = new decimal(new int[] { 100000, 0, 0, 0 });
            nud_maxIterations.ValueChanged += OnMaxTotalIterations_Changed;
            // 
            // nud_minError
            // 
            nud_minError.DecimalPlaces = 2;
            nud_minError.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nud_minError.Location = new Point(114, 679);
            nud_minError.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_minError.Name = "nud_minError";
            nud_minError.Size = new Size(88, 27);
            nud_minError.TabIndex = 10;
            toolTip1.SetToolTip(nud_minError, "Erro mínimo aceito");
            nud_minError.Value = new decimal(new int[] { 2, 0, 0, 131072 });
            nud_minError.ValueChanged += OnErrorThreashold_Changed;
            // 
            // btn_clearGraph
            // 
            btn_clearGraph.IconChar = FontAwesome.Sharp.IconChar.Cancel;
            btn_clearGraph.IconColor = Color.Black;
            btn_clearGraph.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_clearGraph.IconSize = 25;
            btn_clearGraph.Location = new Point(1320, 49);
            btn_clearGraph.Name = "btn_clearGraph";
            btn_clearGraph.Size = new Size(45, 32);
            btn_clearGraph.TabIndex = 8;
            toolTip1.SetToolTip(btn_clearGraph, "Limpa os dados juntamente com os pontos adicionados.");
            btn_clearGraph.UseVisualStyleBackColor = true;
            btn_clearGraph.Click += OnClearGraph_Click;
            // 
            // btn_resetNN
            // 
            btn_resetNN.IconChar = FontAwesome.Sharp.IconChar.RotateRight;
            btn_resetNN.IconColor = Color.Black;
            btn_resetNN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btn_resetNN.IconSize = 25;
            btn_resetNN.Location = new Point(21, 638);
            btn_resetNN.Name = "btn_resetNN";
            btn_resetNN.Size = new Size(45, 32);
            btn_resetNN.TabIndex = 13;
            toolTip1.SetToolTip(btn_resetNN, "Recria a rede neural, isso vai resetar os pesos e bias que já foram aprendidos.");
            btn_resetNN.UseVisualStyleBackColor = true;
            btn_resetNN.Click += OnResetNN_Click;
            // 
            // panel_redeNeuralVisuals
            // 
            panel_redeNeuralVisuals.BorderStyle = BorderStyle.FixedSingle;
            panel_redeNeuralVisuals.Location = new Point(21, 86);
            panel_redeNeuralVisuals.Name = "panel_redeNeuralVisuals";
            panel_redeNeuralVisuals.Size = new Size(655, 542);
            panel_redeNeuralVisuals.TabIndex = 0;
            panel_redeNeuralVisuals.Paint += NeuralNetVisual_Paint;
            // 
            // panel_graph
            // 
            panel_graph.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panel_graph.BackgroundImageLayout = ImageLayout.Stretch;
            panel_graph.BorderStyle = BorderStyle.FixedSingle;
            panel_graph.Location = new Point(710, 86);
            panel_graph.Name = "panel_graph";
            panel_graph.Size = new Size(655, 542);
            panel_graph.TabIndex = 1;
            panel_graph.MouseClick += OnPointAddPanel_Click;
            // 
            // btn_addLayer
            // 
            btn_addLayer.Anchor = AnchorStyles.Left;
            btn_addLayer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_addLayer.Location = new Point(583, 26);
            btn_addLayer.Name = "btn_addLayer";
            btn_addLayer.Size = new Size(31, 29);
            btn_addLayer.TabIndex = 1;
            btn_addLayer.Text = "+";
            btn_addLayer.UseVisualStyleBackColor = true;
            btn_addLayer.Click += OnAddLayer_Click;
            // 
            // btn_removeLayer
            // 
            btn_removeLayer.Anchor = AnchorStyles.Left;
            btn_removeLayer.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btn_removeLayer.Location = new Point(618, 26);
            btn_removeLayer.Name = "btn_removeLayer";
            btn_removeLayer.Size = new Size(31, 29);
            btn_removeLayer.TabIndex = 1;
            btn_removeLayer.Text = "-";
            btn_removeLayer.UseVisualStyleBackColor = true;
            btn_removeLayer.Click += OnRemoveLayer_Click;
            // 
            // nud_layer12
            // 
            nud_layer12.Anchor = AnchorStyles.Left;
            nud_layer12.Location = new Point(535, 26);
            nud_layer12.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer12.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer12.Name = "nud_layer12";
            nud_layer12.Size = new Size(42, 27);
            nud_layer12.TabIndex = 0;
            nud_layer12.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer12.Visible = false;
            nud_layer12.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer11
            // 
            nud_layer11.Anchor = AnchorStyles.Left;
            nud_layer11.Location = new Point(487, 26);
            nud_layer11.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer11.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer11.Name = "nud_layer11";
            nud_layer11.Size = new Size(42, 27);
            nud_layer11.TabIndex = 0;
            nud_layer11.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer11.Visible = false;
            nud_layer11.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer10
            // 
            nud_layer10.Anchor = AnchorStyles.Left;
            nud_layer10.Location = new Point(439, 26);
            nud_layer10.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer10.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer10.Name = "nud_layer10";
            nud_layer10.Size = new Size(42, 27);
            nud_layer10.TabIndex = 0;
            nud_layer10.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer10.Visible = false;
            nud_layer10.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer9
            // 
            nud_layer9.Anchor = AnchorStyles.Left;
            nud_layer9.Location = new Point(391, 26);
            nud_layer9.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer9.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer9.Name = "nud_layer9";
            nud_layer9.Size = new Size(42, 27);
            nud_layer9.TabIndex = 0;
            nud_layer9.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer9.Visible = false;
            nud_layer9.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer8
            // 
            nud_layer8.Anchor = AnchorStyles.Left;
            nud_layer8.Location = new Point(343, 26);
            nud_layer8.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer8.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer8.Name = "nud_layer8";
            nud_layer8.Size = new Size(42, 27);
            nud_layer8.TabIndex = 0;
            nud_layer8.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer8.Visible = false;
            nud_layer8.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer7
            // 
            nud_layer7.Anchor = AnchorStyles.Left;
            nud_layer7.Location = new Point(295, 26);
            nud_layer7.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer7.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer7.Name = "nud_layer7";
            nud_layer7.Size = new Size(42, 27);
            nud_layer7.TabIndex = 0;
            nud_layer7.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer7.Visible = false;
            nud_layer7.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer6
            // 
            nud_layer6.Anchor = AnchorStyles.Left;
            nud_layer6.Location = new Point(247, 26);
            nud_layer6.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer6.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer6.Name = "nud_layer6";
            nud_layer6.Size = new Size(42, 27);
            nud_layer6.TabIndex = 0;
            nud_layer6.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer6.Visible = false;
            nud_layer6.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer5
            // 
            nud_layer5.Anchor = AnchorStyles.Left;
            nud_layer5.Location = new Point(199, 26);
            nud_layer5.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer5.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer5.Name = "nud_layer5";
            nud_layer5.Size = new Size(42, 27);
            nud_layer5.TabIndex = 0;
            nud_layer5.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer5.Visible = false;
            nud_layer5.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer4
            // 
            nud_layer4.Anchor = AnchorStyles.Left;
            nud_layer4.Location = new Point(151, 26);
            nud_layer4.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer4.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer4.Name = "nud_layer4";
            nud_layer4.Size = new Size(42, 27);
            nud_layer4.TabIndex = 0;
            nud_layer4.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer4.Visible = false;
            nud_layer4.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer3
            // 
            nud_layer3.Anchor = AnchorStyles.Left;
            nud_layer3.Location = new Point(103, 26);
            nud_layer3.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer3.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer3.Name = "nud_layer3";
            nud_layer3.Size = new Size(42, 27);
            nud_layer3.TabIndex = 0;
            nud_layer3.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer3.Visible = false;
            nud_layer3.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer2
            // 
            nud_layer2.Anchor = AnchorStyles.Left;
            nud_layer2.Enabled = false;
            nud_layer2.Location = new Point(55, 26);
            nud_layer2.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer2.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer2.Name = "nud_layer2";
            nud_layer2.Size = new Size(42, 27);
            nud_layer2.TabIndex = 0;
            nud_layer2.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer2.ValueChanged += OnLayerConfig_Changed;
            // 
            // nud_layer1
            // 
            nud_layer1.Anchor = AnchorStyles.Left;
            nud_layer1.Enabled = false;
            nud_layer1.Location = new Point(7, 26);
            nud_layer1.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            nud_layer1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nud_layer1.Name = "nud_layer1";
            nud_layer1.Size = new Size(42, 27);
            nud_layer1.TabIndex = 0;
            nud_layer1.Value = new decimal(new int[] { 2, 0, 0, 0 });
            nud_layer1.ValueChanged += OnLayerConfig_Changed;
            // 
            // CamadasGroup
            // 
            CamadasGroup.Controls.Add(nud_layer11);
            CamadasGroup.Controls.Add(btn_addLayer);
            CamadasGroup.Controls.Add(nud_layer4);
            CamadasGroup.Controls.Add(nud_layer5);
            CamadasGroup.Controls.Add(btn_removeLayer);
            CamadasGroup.Controls.Add(nud_layer3);
            CamadasGroup.Controls.Add(nud_layer12);
            CamadasGroup.Controls.Add(nud_layer6);
            CamadasGroup.Controls.Add(nud_layer2);
            CamadasGroup.Controls.Add(nud_layer7);
            CamadasGroup.Controls.Add(nud_layer1);
            CamadasGroup.Controls.Add(nud_layer10);
            CamadasGroup.Controls.Add(nud_layer8);
            CamadasGroup.Controls.Add(nud_layer9);
            CamadasGroup.Location = new Point(21, 18);
            CamadasGroup.Name = "CamadasGroup";
            CamadasGroup.Size = new Size(651, 62);
            CamadasGroup.TabIndex = 5;
            CamadasGroup.TabStop = false;
            CamadasGroup.Text = "Camadas";
            // 
            // ch_red
            // 
            ch_red.Appearance = Appearance.Button;
            ch_red.BackColor = Color.Black;
            ch_red.CheckAlign = ContentAlignment.MiddleCenter;
            ch_red.FlatAppearance.BorderColor = Color.Red;
            ch_red.FlatAppearance.BorderSize = 7;
            ch_red.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_red.FlatStyle = FlatStyle.Flat;
            ch_red.Location = new Point(710, 50);
            ch_red.Name = "ch_red";
            ch_red.Size = new Size(31, 30);
            ch_red.TabIndex = 6;
            ch_red.UseVisualStyleBackColor = false;
            ch_red.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_orange
            // 
            ch_orange.Appearance = Appearance.Button;
            ch_orange.BackColor = Color.Black;
            ch_orange.CheckAlign = ContentAlignment.MiddleCenter;
            ch_orange.FlatAppearance.BorderColor = Color.FromArgb(255, 128, 0);
            ch_orange.FlatAppearance.BorderSize = 7;
            ch_orange.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_orange.FlatStyle = FlatStyle.Flat;
            ch_orange.Location = new Point(747, 50);
            ch_orange.Name = "ch_orange";
            ch_orange.Size = new Size(31, 30);
            ch_orange.TabIndex = 6;
            ch_orange.UseVisualStyleBackColor = false;
            ch_orange.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_yellow
            // 
            ch_yellow.Appearance = Appearance.Button;
            ch_yellow.BackColor = Color.Black;
            ch_yellow.CheckAlign = ContentAlignment.MiddleCenter;
            ch_yellow.FlatAppearance.BorderColor = Color.Yellow;
            ch_yellow.FlatAppearance.BorderSize = 7;
            ch_yellow.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_yellow.FlatStyle = FlatStyle.Flat;
            ch_yellow.Location = new Point(784, 50);
            ch_yellow.Name = "ch_yellow";
            ch_yellow.Size = new Size(31, 30);
            ch_yellow.TabIndex = 6;
            ch_yellow.UseVisualStyleBackColor = false;
            ch_yellow.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_green
            // 
            ch_green.Appearance = Appearance.Button;
            ch_green.BackColor = Color.Black;
            ch_green.CheckAlign = ContentAlignment.MiddleCenter;
            ch_green.FlatAppearance.BorderColor = Color.Lime;
            ch_green.FlatAppearance.BorderSize = 7;
            ch_green.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_green.FlatStyle = FlatStyle.Flat;
            ch_green.Location = new Point(821, 50);
            ch_green.Name = "ch_green";
            ch_green.Size = new Size(31, 30);
            ch_green.TabIndex = 6;
            ch_green.UseVisualStyleBackColor = false;
            ch_green.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_cyan
            // 
            ch_cyan.Appearance = Appearance.Button;
            ch_cyan.BackColor = Color.Black;
            ch_cyan.CheckAlign = ContentAlignment.MiddleCenter;
            ch_cyan.FlatAppearance.BorderColor = Color.Cyan;
            ch_cyan.FlatAppearance.BorderSize = 7;
            ch_cyan.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_cyan.FlatStyle = FlatStyle.Flat;
            ch_cyan.Location = new Point(858, 50);
            ch_cyan.Name = "ch_cyan";
            ch_cyan.Size = new Size(31, 30);
            ch_cyan.TabIndex = 6;
            ch_cyan.UseVisualStyleBackColor = false;
            ch_cyan.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_blue
            // 
            ch_blue.Appearance = Appearance.Button;
            ch_blue.BackColor = Color.Black;
            ch_blue.CheckAlign = ContentAlignment.MiddleCenter;
            ch_blue.FlatAppearance.BorderColor = Color.Blue;
            ch_blue.FlatAppearance.BorderSize = 7;
            ch_blue.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_blue.FlatStyle = FlatStyle.Flat;
            ch_blue.Location = new Point(895, 50);
            ch_blue.Name = "ch_blue";
            ch_blue.Size = new Size(31, 30);
            ch_blue.TabIndex = 6;
            ch_blue.UseVisualStyleBackColor = false;
            ch_blue.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_pink
            // 
            ch_pink.Appearance = Appearance.Button;
            ch_pink.BackColor = Color.Black;
            ch_pink.CheckAlign = ContentAlignment.MiddleCenter;
            ch_pink.FlatAppearance.BorderColor = Color.Fuchsia;
            ch_pink.FlatAppearance.BorderSize = 7;
            ch_pink.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_pink.FlatStyle = FlatStyle.Flat;
            ch_pink.Location = new Point(932, 50);
            ch_pink.Name = "ch_pink";
            ch_pink.Size = new Size(31, 30);
            ch_pink.TabIndex = 6;
            ch_pink.UseVisualStyleBackColor = false;
            ch_pink.CheckedChanged += OnColorPicker_Changed;
            // 
            // ch_purple
            // 
            ch_purple.Appearance = Appearance.Button;
            ch_purple.BackColor = Color.Black;
            ch_purple.CheckAlign = ContentAlignment.MiddleCenter;
            ch_purple.FlatAppearance.BorderColor = Color.BlueViolet;
            ch_purple.FlatAppearance.BorderSize = 7;
            ch_purple.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            ch_purple.FlatStyle = FlatStyle.Flat;
            ch_purple.Location = new Point(969, 50);
            ch_purple.Name = "ch_purple";
            ch_purple.Size = new Size(31, 30);
            ch_purple.TabIndex = 6;
            ch_purple.UseVisualStyleBackColor = false;
            ch_purple.CheckedChanged += OnColorPicker_Changed;
            // 
            // checkBox9
            // 
            checkBox9.Appearance = Appearance.Button;
            checkBox9.BackColor = Color.Black;
            checkBox9.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox9.FlatAppearance.BorderColor = Color.Red;
            checkBox9.FlatAppearance.BorderSize = 7;
            checkBox9.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox9.FlatStyle = FlatStyle.Flat;
            checkBox9.Location = new Point(1006, 50);
            checkBox9.Name = "checkBox9";
            checkBox9.Size = new Size(31, 30);
            checkBox9.TabIndex = 6;
            checkBox9.UseVisualStyleBackColor = false;
            checkBox9.Visible = false;
            // 
            // checkBox10
            // 
            checkBox10.Appearance = Appearance.Button;
            checkBox10.BackColor = Color.Black;
            checkBox10.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox10.FlatAppearance.BorderColor = Color.Red;
            checkBox10.FlatAppearance.BorderSize = 7;
            checkBox10.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox10.FlatStyle = FlatStyle.Flat;
            checkBox10.Location = new Point(1043, 50);
            checkBox10.Name = "checkBox10";
            checkBox10.Size = new Size(31, 30);
            checkBox10.TabIndex = 6;
            checkBox10.UseVisualStyleBackColor = false;
            checkBox10.Visible = false;
            // 
            // checkBox11
            // 
            checkBox11.Appearance = Appearance.Button;
            checkBox11.BackColor = Color.Black;
            checkBox11.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox11.FlatAppearance.BorderColor = Color.Red;
            checkBox11.FlatAppearance.BorderSize = 7;
            checkBox11.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox11.FlatStyle = FlatStyle.Flat;
            checkBox11.Location = new Point(1080, 50);
            checkBox11.Name = "checkBox11";
            checkBox11.Size = new Size(31, 30);
            checkBox11.TabIndex = 6;
            checkBox11.UseVisualStyleBackColor = false;
            checkBox11.Visible = false;
            // 
            // checkBox12
            // 
            checkBox12.Appearance = Appearance.Button;
            checkBox12.BackColor = Color.Black;
            checkBox12.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox12.FlatAppearance.BorderColor = Color.Red;
            checkBox12.FlatAppearance.BorderSize = 7;
            checkBox12.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox12.FlatStyle = FlatStyle.Flat;
            checkBox12.Location = new Point(1117, 50);
            checkBox12.Name = "checkBox12";
            checkBox12.Size = new Size(31, 30);
            checkBox12.TabIndex = 6;
            checkBox12.UseVisualStyleBackColor = false;
            checkBox12.Visible = false;
            // 
            // checkBox13
            // 
            checkBox13.Appearance = Appearance.Button;
            checkBox13.BackColor = Color.Black;
            checkBox13.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox13.FlatAppearance.BorderColor = Color.Red;
            checkBox13.FlatAppearance.BorderSize = 7;
            checkBox13.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox13.FlatStyle = FlatStyle.Flat;
            checkBox13.Location = new Point(1154, 50);
            checkBox13.Name = "checkBox13";
            checkBox13.Size = new Size(31, 30);
            checkBox13.TabIndex = 6;
            checkBox13.UseVisualStyleBackColor = false;
            checkBox13.Visible = false;
            // 
            // checkBox14
            // 
            checkBox14.Appearance = Appearance.Button;
            checkBox14.BackColor = Color.Black;
            checkBox14.CheckAlign = ContentAlignment.MiddleCenter;
            checkBox14.FlatAppearance.BorderColor = Color.Red;
            checkBox14.FlatAppearance.BorderSize = 7;
            checkBox14.FlatAppearance.CheckedBackColor = Color.FromArgb(192, 255, 192);
            checkBox14.FlatStyle = FlatStyle.Flat;
            checkBox14.Location = new Point(1191, 50);
            checkBox14.Name = "checkBox14";
            checkBox14.Size = new Size(31, 30);
            checkBox14.TabIndex = 6;
            checkBox14.UseVisualStyleBackColor = false;
            checkBox14.Visible = false;
            // 
            // iconButton1
            // 
            iconButton1.Enabled = false;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Cog;
            iconButton1.IconColor = Color.Black;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.IconSize = 25;
            iconButton1.Location = new Point(1269, 49);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(45, 32);
            iconButton1.TabIndex = 8;
            iconButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Visible = false;
            // 
            // btn_StartTrain
            // 
            btn_StartTrain.Location = new Point(556, 634);
            btn_StartTrain.Name = "btn_StartTrain";
            btn_StartTrain.Size = new Size(120, 36);
            btn_StartTrain.TabIndex = 9;
            btn_StartTrain.Text = "Train";
            btn_StartTrain.UseVisualStyleBackColor = true;
            btn_StartTrain.Click += OnStartTraining_Click;
            // 
            // label_Error
            // 
            label_Error.AutoSize = true;
            label_Error.Font = new Font("Segoe UI", 15F);
            label_Error.Location = new Point(710, 634);
            label_Error.Name = "label_Error";
            label_Error.Size = new Size(90, 35);
            label_Error.TabIndex = 11;
            label_Error.Text = "Error 0";
            // 
            // label_Iteration
            // 
            label_Iteration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label_Iteration.Font = new Font("Segoe UI", 15F);
            label_Iteration.Location = new Point(980, 634);
            label_Iteration.Name = "label_Iteration";
            label_Iteration.RightToLeft = RightToLeft.No;
            label_Iteration.Size = new Size(385, 35);
            label_Iteration.TabIndex = 11;
            label_Iteration.Text = "Iteration 0";
            label_Iteration.TextAlign = ContentAlignment.TopRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1179, 687);
            label1.Name = "label1";
            label1.Size = new Size(92, 20);
            label1.TabIndex = 12;
            label1.Text = "Update Rate";
            // 
            // btn_StopTrain
            // 
            btn_StopTrain.Enabled = false;
            btn_StopTrain.Location = new Point(556, 676);
            btn_StopTrain.Name = "btn_StopTrain";
            btn_StopTrain.Size = new Size(120, 36);
            btn_StopTrain.TabIndex = 9;
            btn_StopTrain.Text = "Stop";
            btn_StopTrain.UseVisualStyleBackColor = true;
            btn_StopTrain.Click += OnStopTrainin_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(208, 714);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 12;
            label2.Text = "Max Iterations";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(208, 648);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 12;
            label3.Text = "Taxa de Aprendizado";
            // 
            // ch_useCos
            // 
            ch_useCos.AutoSize = true;
            ch_useCos.Location = new Point(424, 646);
            ch_useCos.Name = "ch_useCos";
            ch_useCos.Size = new Size(119, 24);
            ch_useCos.TabIndex = 14;
            ch_useCos.Text = "Usar Cosseno";
            ch_useCos.UseVisualStyleBackColor = true;
            ch_useCos.CheckedChanged += OnUseCos_Changed;
            // 
            // ch_useAtan2
            // 
            ch_useAtan2.AutoSize = true;
            ch_useAtan2.Location = new Point(424, 713);
            ch_useAtan2.Name = "ch_useAtan2";
            ch_useAtan2.Size = new Size(103, 24);
            ch_useAtan2.TabIndex = 14;
            ch_useAtan2.Text = "Usar Atan2";
            ch_useAtan2.UseVisualStyleBackColor = true;
            ch_useAtan2.CheckedChanged += OnUseAtan2_Changed;
            // 
            // ch_useSin
            // 
            ch_useSin.AutoSize = true;
            ch_useSin.Location = new Point(424, 680);
            ch_useSin.Name = "ch_useSin";
            ch_useSin.Size = new Size(97, 24);
            ch_useSin.TabIndex = 14;
            ch_useSin.Text = "Usar Seno";
            ch_useSin.UseVisualStyleBackColor = true;
            ch_useSin.CheckedChanged += OnUseSin_Changed;
            // 
            // numericUpDown1
            // 
            numericUpDown1.DecimalPlaces = 2;
            numericUpDown1.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDown1.Location = new Point(114, 646);
            numericUpDown1.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(88, 27);
            numericUpDown1.TabIndex = 10;
            numericUpDown1.Value = new decimal(new int[] { 5, 0, 0, 131072 });
            numericUpDown1.ValueChanged += OnLearningRate_Changed;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(208, 681);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 12;
            label4.Text = "Erro Mínimo Aceito";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1390, 753);
            Controls.Add(ch_useSin);
            Controls.Add(ch_useAtan2);
            Controls.Add(ch_useCos);
            Controls.Add(btn_resetNN);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_Iteration);
            Controls.Add(label_Error);
            Controls.Add(numericUpDown1);
            Controls.Add(nud_minError);
            Controls.Add(nud_maxIterations);
            Controls.Add(nud_updateRate);
            Controls.Add(btn_StopTrain);
            Controls.Add(btn_StartTrain);
            Controls.Add(btn_clearGraph);
            Controls.Add(iconButton1);
            Controls.Add(checkBox14);
            Controls.Add(checkBox13);
            Controls.Add(checkBox12);
            Controls.Add(checkBox11);
            Controls.Add(checkBox10);
            Controls.Add(checkBox9);
            Controls.Add(ch_purple);
            Controls.Add(ch_pink);
            Controls.Add(ch_blue);
            Controls.Add(ch_cyan);
            Controls.Add(ch_green);
            Controls.Add(ch_yellow);
            Controls.Add(ch_orange);
            Controls.Add(ch_red);
            Controls.Add(CamadasGroup);
            Controls.Add(panel_graph);
            Controls.Add(panel_redeNeuralVisuals);
            MaximumSize = new Size(1408, 800);
            MinimumSize = new Size(1408, 800);
            Name = "Form1";
            Text = "Form1";
            Load += OnForm_Load;
            ((System.ComponentModel.ISupportInitialize)nud_updateRate).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_maxIterations).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_minError).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer12).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer11).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer10).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer9).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer8).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer7).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer6).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer5).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer4).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer3).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer2).EndInit();
            ((System.ComponentModel.ISupportInitialize)nud_layer1).EndInit();
            CamadasGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolTip toolTip1;
        private DoubleBufferedPanel panel_redeNeuralVisuals;
        private DoubleBufferedPanel panel_graph;
        private Button btn_removeLayer;
        private NumericUpDown nud_layer12;
        private NumericUpDown nud_layer11;
        private NumericUpDown nud_layer10;
        private NumericUpDown nud_layer9;
        private NumericUpDown nud_layer8;
        private NumericUpDown nud_layer7;
        private NumericUpDown nud_layer6;
        private NumericUpDown nud_layer5;
        private NumericUpDown nud_layer4;
        private NumericUpDown nud_layer3;
        private NumericUpDown nud_layer2;
        private NumericUpDown nud_layer1;
        private Button btn_addLayer;
        private GroupBox CamadasGroup;
        private CheckBox ch_red;
        private CheckBox ch_orange;
        private CheckBox ch_yellow;
        private CheckBox ch_green;
        private CheckBox ch_cyan;
        private CheckBox ch_blue;
        private CheckBox ch_pink;
        private CheckBox ch_purple;
        private CheckBox checkBox9;
        private CheckBox checkBox10;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
        private CheckBox checkBox13;
        private CheckBox checkBox14;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btn_clearGraph;
        private Button btn_StartTrain;
        private Label label_Error;
        private Label label_Iteration;
        private NumericUpDown nud_updateRate;
        private Label label1;
        private Button btn_StopTrain;
        private FontAwesome.Sharp.IconButton btn_resetNN;
        private NumericUpDown nud_maxIterations;
        private Label label2;
        private NumericUpDown nud_minError;
        private Label label3;
        private CheckBox ch_useCos;
        private CheckBox ch_useAtan2;
        private CheckBox ch_useSin;
        private NumericUpDown numericUpDown1;
        private Label label4;
    }


}


