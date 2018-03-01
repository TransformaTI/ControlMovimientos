Imports PortatilClasses.Lista

Public Class frmMedicionPCFlujo
    Inherits System.Windows.Forms.Form

    Private ListaDatos As New ArrayList()
    Private Medicion As Integer

    Public Ducto As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents txtTasaMasa As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents dtpFHMedicion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtVolumen As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtMasa As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtDensidad As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPresion As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTemperatura As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTasaVol As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents dgMedicion As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMedicionPCFlujo))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtTasaVol = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTemperatura = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPresion = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtDensidad = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtMasa = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtVolumen = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.dgMedicion = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.txtTasaMasa = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpFHMedicion = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgMedicion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTasaVol, Me.txtTemperatura, Me.txtPresion, Me.txtDensidad, Me.txtMasa, Me.txtVolumen, Me.dgMedicion, Me.txtTasaMasa, Me.Label6, Me.Label5, Me.Label4, Me.dtpFHMedicion, Me.Label44, Me.Label18, Me.Label19, Me.Label20, Me.Label22})
        Me.grpDatos.Location = New System.Drawing.Point(16, 8)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 400)
        Me.grpDatos.TabIndex = 132
        Me.grpDatos.TabStop = False
        '
        'txtTasaVol
        '
        Me.txtTasaVol.AutoSize = False
        Me.txtTasaVol.Location = New System.Drawing.Point(167, 192)
        Me.txtTasaVol.MaxLength = 10
        Me.txtTasaVol.Name = "txtTasaVol"
        Me.txtTasaVol.Size = New System.Drawing.Size(216, 21)
        Me.txtTasaVol.TabIndex = 6
        Me.txtTasaVol.Text = "TxtNumeroDecimal3"
        '
        'txtTemperatura
        '
        Me.txtTemperatura.AutoSize = False
        Me.txtTemperatura.Location = New System.Drawing.Point(167, 164)
        Me.txtTemperatura.MaxLength = 10
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.Size = New System.Drawing.Size(216, 21)
        Me.txtTemperatura.TabIndex = 5
        Me.txtTemperatura.Text = "TxtNumeroDecimal3"
        '
        'txtPresion
        '
        Me.txtPresion.AutoSize = False
        Me.txtPresion.Location = New System.Drawing.Point(167, 136)
        Me.txtPresion.MaxLength = 10
        Me.txtPresion.Name = "txtPresion"
        Me.txtPresion.Size = New System.Drawing.Size(216, 21)
        Me.txtPresion.TabIndex = 4
        Me.txtPresion.Text = "TxtNumeroDecimal3"
        '
        'txtDensidad
        '
        Me.txtDensidad.AutoSize = False
        Me.txtDensidad.Location = New System.Drawing.Point(167, 108)
        Me.txtDensidad.MaxLength = 10
        Me.txtDensidad.Name = "txtDensidad"
        Me.txtDensidad.Size = New System.Drawing.Size(216, 21)
        Me.txtDensidad.TabIndex = 3
        Me.txtDensidad.Text = "TxtNumeroDecimal3"
        '
        'txtMasa
        '
        Me.txtMasa.AutoSize = False
        Me.txtMasa.Location = New System.Drawing.Point(167, 80)
        Me.txtMasa.MaxLength = 10
        Me.txtMasa.Name = "txtMasa"
        Me.txtMasa.Size = New System.Drawing.Size(216, 21)
        Me.txtMasa.TabIndex = 2
        Me.txtMasa.Text = "TxtNumeroDecimal3"
        '
        'txtVolumen
        '
        Me.txtVolumen.AutoSize = False
        Me.txtVolumen.Location = New System.Drawing.Point(167, 52)
        Me.txtVolumen.MaxLength = 10
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(216, 21)
        Me.txtVolumen.TabIndex = 1
        Me.txtVolumen.Text = "TxtNumeroDecimal3"
        '
        'dgMedicion
        '
        Me.dgMedicion.DataMember = ""
        Me.dgMedicion.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgMedicion.Location = New System.Drawing.Point(2, 248)
        Me.dgMedicion.Name = "dgMedicion"
        Me.dgMedicion.ReadOnly = True
        Me.dgMedicion.Size = New System.Drawing.Size(485, 152)
        Me.dgMedicion.TabIndex = 8
        Me.dgMedicion.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.dgMedicion.TabStop = False
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgMedicion
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Fecha medición"
        Me.DataGridTextBoxColumn1.MappingName = "FHMedicion"
        Me.DataGridTextBoxColumn1.Width = 130
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Volumen"
        Me.DataGridTextBoxColumn2.MappingName = "Volumen"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Masa"
        Me.DataGridTextBoxColumn3.MappingName = "Masa"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Densidad"
        Me.DataGridTextBoxColumn4.MappingName = "Densidad"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Presión"
        Me.DataGridTextBoxColumn5.MappingName = "Presion"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Temperatura"
        Me.DataGridTextBoxColumn6.MappingName = "Temperatura"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Tasa volumen"
        Me.DataGridTextBoxColumn7.MappingName = "TasaVol"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Tasa masa"
        Me.DataGridTextBoxColumn8.MappingName = "TasaMasa"
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'txtTasaMasa
        '
        Me.txtTasaMasa.AutoSize = False
        Me.txtTasaMasa.Location = New System.Drawing.Point(167, 220)
        Me.txtTasaMasa.MaxLength = 10
        Me.txtTasaMasa.Name = "txtTasaMasa"
        Me.txtTasaMasa.Size = New System.Drawing.Size(216, 21)
        Me.txtTasaMasa.TabIndex = 7
        Me.txtTasaMasa.Text = "TxtNumeroDecimal3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 224)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(112, 13)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Tasa masa (Kg/hr):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 140)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 13)
        Me.Label5.TabIndex = 146
        Me.Label5.Text = "Presión (Kg/m2):"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 13)
        Me.Label4.TabIndex = 145
        Me.Label4.Text = "Densidad  (Kg/m3):"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFHMedicion
        '
        Me.dtpFHMedicion.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFHMedicion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFHMedicion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFHMedicion.Location = New System.Drawing.Point(167, 24)
        Me.dtpFHMedicion.Name = "dtpFHMedicion"
        Me.dtpFHMedicion.Size = New System.Drawing.Size(216, 21)
        Me.dtpFHMedicion.TabIndex = 0
        Me.dtpFHMedicion.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(16, 84)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(93, 13)
        Me.Label44.TabIndex = 138
        Me.Label44.Text = "Masa total (Kg):"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(16, 196)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(146, 13)
        Me.Label18.TabIndex = 137
        Me.Label18.Text = "Tasa volumen (Barril/hr):"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(16, 168)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 13)
        Me.Label19.TabIndex = 136
        Me.Label19.Text = "Temperatura (°C):"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(16, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(125, 13)
        Me.Label20.TabIndex = 135
        Me.Label20.Text = "Fecha hora medición :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(16, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(116, 13)
        Me.Label22.TabIndex = 134
        Me.Label22.Text = "Volumen total (m3):"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(512, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 23)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(512, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnQuitar
        '
        Me.btnQuitar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitar.Image = CType(resources.GetObject("btnQuitar.Image"), System.Drawing.Bitmap)
        Me.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnQuitar.Location = New System.Drawing.Point(512, 321)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(80, 23)
        Me.btnQuitar.TabIndex = 5
        Me.btnQuitar.Text = "&Quitar"
        Me.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnModificar
        '
        Me.btnModificar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Bitmap)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModificar.Location = New System.Drawing.Point(512, 289)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(80, 23)
        Me.btnModificar.TabIndex = 4
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(512, 257)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 23)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "A&gregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.Image = CType(resources.GetObject("btnLimpiar.Image"), System.Drawing.Bitmap)
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.Location = New System.Drawing.Point(512, 80)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 23)
        Me.btnLimpiar.TabIndex = 3
        Me.btnLimpiar.Text = "&Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMedicionPCFlujo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(598, 422)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnLimpiar, Me.btnQuitar, Me.btnModificar, Me.btnAgregar, Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMedicionPCFlujo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mediciones de la computadora de flujo"
        Me.grpDatos.ResumeLayout(False)
        CType(Me.dgMedicion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Limpiar()
        txtVolumen.Clear()
        txtMasa.Clear()
        txtDensidad.Clear()
        txtPresion.Clear()
        txtTemperatura.Clear()
        txtTasaVol.Clear()
        txtTasaMasa.Clear()
        'btnAceptar.Enabled = False
        btnAgregar.Enabled = False
        btnModificar.Enabled = False
    End Sub

    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If ListaDatos.Count > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAgregar()
        If txtVolumen.Text <> "" And txtMasa.Text <> "" And txtDensidad.Text <> "" And txtPresion.Text <> "" And _
        txtTemperatura.Text <> "" And txtTasaVol.Text <> "" And txtTasaMasa.Text <> "" Then
            btnAgregar.Enabled = True
            If Medicion > -1 Then
                btnModificar.Enabled = True
            End If
        Else
            btnAgregar.Enabled = False
            If Medicion > -1 Then
                btnModificar.Enabled = False
            End If
        End If
    End Sub

    Private Sub DesplegarDatos()
        Dim dvMedicion As DataView
        Dim dtMedicion As DataTable = New DataTable()
        Dim dcoMedicion As DataColumn
        Dim droMedicion As DataRow

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = System.Type.GetType("System.DateTime")
        dcoMedicion.ColumnName = "FHMedicion"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "Volumen"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "Masa"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "Densidad"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "Presion"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "Temperatura"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "TasaVol"
        dtMedicion.Columns.Add(dcoMedicion)

        dcoMedicion = New DataColumn()
        dcoMedicion.DataType = Type.GetType("System.Decimal")
        dcoMedicion.ColumnName = "TasaMasa"
        dtMedicion.Columns.Add(dcoMedicion)

        Dim i As Integer
        For i = 0 To ListaDatos.Count - 1
            Dim oListaMedicion As cMedicionPCFlujo
            oListaMedicion = CType(ListaDatos.Item(i), cMedicionPCFlujo)

            droMedicion = dtMedicion.NewRow()
            droMedicion("FHMedicion") = oListaMedicion.FHMedicion
            droMedicion("Volumen") = oListaMedicion.Volumen
            droMedicion("Masa") = oListaMedicion.Masa
            droMedicion("Densidad") = oListaMedicion.Densidad
            droMedicion("Presion") = oListaMedicion.Presion
            droMedicion("Temperatura") = oListaMedicion.Temperatura
            droMedicion("TasaVol") = oListaMedicion.TasaVol
            droMedicion("TasaMasa") = oListaMedicion.TasaMasa
            dtMedicion.Rows.Add(droMedicion)
        Next
        dvMedicion = New DataView(dtMedicion)
        dgMedicion.DataSource = dvMedicion
    End Sub


    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As DateTime
        Dim Fecha As DateTime
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, 0)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    Private Function ExisteMedicion(ByVal FHMedicion As DateTime) As Boolean
        Dim oListaMedicion As cMedicionPCFlujo
        Dim i As Integer
        Dim Existe As Boolean = False
        For i = 0 To ListaDatos.Count() - 1
            oListaMedicion = CType(ListaDatos.Item(i), cMedicionPCFlujo)
            If oListaMedicion.FHMedicion = FHMedicion Then
                Existe = True
            End If
        Next
        Return Existe
    End Function

    Private Sub Agregarmedicion()
        If ExisteMedicion(dtpFHMedicion.Value) = False Then
            Dim oListaMedicion As New cMedicionPCFlujo(dtpFHMedicion.Value, CType(txtVolumen.Text, Decimal), _
                CType(txtMasa.Text, Decimal), CType(txtDensidad.Text, Decimal), CType(txtPresion.Text, Decimal), _
                CType(txtTemperatura.Text, Decimal), CType(txtTasaVol.Text, Decimal), CType(txtTasaMasa.Text, Decimal))
            ListaDatos.Add(oListaMedicion)
            'dgMedicion.DataSource = Nothing
            'dgMedicion.DataSource = ListaDatos
            DesplegarDatos()
            Limpiar()
            dtpFHMedicion.Value = dtpFHMedicion.Value.AddMinutes(30)
            ActiveControl = dtpFHMedicion
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(78)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Mensajes = Nothing
            ActiveControl = dtpFHMedicion
        End If
        Medicion = -1
        btnModificar.Enabled = False
    End Sub

    Private Sub BorrarMedicion()
        Dim oListaMedicion As cMedicionPCFlujo
        If (dgMedicion.CurrentRowIndex > -1) And (ListaDatos.Count > 0) Then
            oListaMedicion = CType(ListaDatos.Item(dgMedicion.CurrentRowIndex), cMedicionPCFlujo)
            ListaDatos.Remove(oListaMedicion)
            'dgMedicion.DataSource = Nothing
            'dgMedicion.DataSource = ListaDatos
            DesplegarDatos()
        End If
        Medicion = -1
        btnModificar.Enabled = False
    End Sub

    Private Sub ModificarMedicion()
        Dim oListaMedicion As cMedicionPCFlujo
        oListaMedicion = CType(ListaDatos.Item(Medicion), cMedicionPCFlujo)
        oListaMedicion.FHMedicion = dtpFHMedicion.Value
        oListaMedicion.Volumen = CType(txtVolumen.Text, Decimal)
        oListaMedicion.Densidad = CType(txtDensidad.Text, Decimal)
        oListaMedicion.Masa = CType(txtMasa.Text, Decimal)
        oListaMedicion.Presion = CType(txtPresion.Text, Decimal)
        oListaMedicion.TasaMasa = CType(txtTasaMasa.Text, Decimal)
        oListaMedicion.TasaVol = CType(txtTasaVol.Text, Decimal)
        oListaMedicion.Temperatura = CType(txtTemperatura.Text, Decimal)
        'dgMedicion.DataSource = Nothing
        'dgMedicion.DataSource = ListaDatos
        DesplegarDatos()
        Limpiar()
        btnModificar.Enabled = False
    End Sub

    Private Sub CargarMedicion()
        Dim oListaMedicion As cMedicionPCFlujo
        If (dgMedicion.CurrentRowIndex > -1) And (ListaDatos.Count > 0) Then
            Medicion = dgMedicion.CurrentRowIndex
            oListaMedicion = CType(ListaDatos.Item(dgMedicion.CurrentRowIndex), cMedicionPCFlujo)
            dtpFHMedicion.Value = oListaMedicion.FHMedicion
            txtVolumen.Text = CType(oListaMedicion.Volumen, String)
            txtMasa.Text = CType(oListaMedicion.Masa, String)
            txtDensidad.Text = CType(oListaMedicion.Densidad, String)
            txtPresion.Text = CType(oListaMedicion.Presion, String)
            txtTemperatura.Text = CType(oListaMedicion.Temperatura, String)
            txtTasaVol.Text = CType(oListaMedicion.TasaVol, String)
            txtTasaMasa.Text = CType(oListaMedicion.TasaMasa, String)
        End If
    End Sub

    Private Sub RegistrarMedicion(ByVal oListaMedicion As cMedicionPCFlujo, ByVal i As Integer)
        Dim oMedicionPCFlujo As New PortatilClasses.Consulta.cMedicionPCFlujo(0)
        oMedicionPCFlujo.Registrar(i + 1, Ducto, oListaMedicion.FHMedicion, oListaMedicion.Volumen, oListaMedicion.Masa, _
                         oListaMedicion.Densidad, oListaMedicion.Presion, oListaMedicion.Temperatura, _
                         oListaMedicion.TasaVol, oListaMedicion.TasaMasa, GLOBAL_Usuario)
    End Sub

    Private Sub RegistrarMediciones()
        Refresh()
        Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim oMedicionPCFlujo As New PortatilClasses.Consulta.cMedicionPCFlujo(2)
        oMedicionPCFlujo.Consultar(Ducto)
        Dim oListaMedicion As cMedicionPCFlujo
        For i = 0 To ListaDatos.Count - 1
            oListaMedicion = CType(ListaDatos.Item(i), cMedicionPCFlujo)
            RegistrarMedicion(oListaMedicion, i)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub CargarMediciones()
        Cursor = Cursors.WaitCursor
        Dim oMedicionPCFlujo As New PortatilClasses.Consulta.cMedicionPCFlujo(1)
        oMedicionPCFlujo.Consultar(Ducto)
        Do While oMedicionPCFlujo.drAlmacen.Read()
            Dim oListaMedicion As New cMedicionPCFlujo(CType(oMedicionPCFlujo.drAlmacen(2), DateTime), _
                CType(oMedicionPCFlujo.drAlmacen(3), Decimal), CType(oMedicionPCFlujo.drAlmacen(4), Decimal), _
                CType(oMedicionPCFlujo.drAlmacen(5), Decimal), CType(oMedicionPCFlujo.drAlmacen(6), Decimal), _
                CType(oMedicionPCFlujo.drAlmacen(7), Decimal), CType(oMedicionPCFlujo.drAlmacen(8), Decimal), _
                CType(oMedicionPCFlujo.drAlmacen(9), Decimal))
            ListaDatos.Add(oListaMedicion)
        Loop
        'dgMedicion.DataSource = Nothing
        'dgMedicion.DataSource = ListaDatos
        DesplegarDatos()
        Cursor = Cursors.Default
    End Sub

    Private Sub frmMedicionPCFlujo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFHMedicion.Value = FechaActual()
        Limpiar()
        ActiveControl = dtpFHMedicion
        Medicion = -1
        CargarMediciones()
    End Sub

    Private Sub dtpFHMedicion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFHMedicion.KeyDown, dgMedicion.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtVolumen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtVolumen.KeyDown, txtDensidad.KeyDown, txtMasa.KeyDown, txtPresion.KeyDown, txtTasaMasa.KeyDown, txtTasaVol.KeyDown, txtTemperatura.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Agregarmedicion()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click
        BorrarMedicion()
    End Sub

    Private Sub dgMedicion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dgMedicion.DoubleClick
        If (dgMedicion.CurrentRowIndex > -1) And (ListaDatos.Count > 0) Then
            btnModificar.Enabled = True
            CargarMedicion()
        End If
    End Sub

    Private Sub dtpFHMedicion_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFHMedicion.TextChanged, txtDensidad.TextChanged, txtMasa.TextChanged, txtPresion.TextChanged, _
    txtTasaMasa.TextChanged, txtTasaVol.TextChanged, txtTemperatura.TextChanged, txtVolumen.TextChanged, _
    dgMedicion.TextChanged
        HabilitarAceptar()
        HabilitarAgregar()
    End Sub

    Private Sub btnModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModificar.Click
        ModificarMedicion()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            RegistrarMediciones()
            Close()
        End If
    End Sub
End Class
