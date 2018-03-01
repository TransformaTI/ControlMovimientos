Public Class frmConsultaDucto
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Grid As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnMedicion As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaDucto))
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.Grid = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.btnMedicion = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtpFFin
        '
        Me.dtpFFin.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFFin.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFFin.Location = New System.Drawing.Point(606, 11)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.Size = New System.Drawing.Size(100, 20)
        Me.dtpFFin.TabIndex = 41
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(712, 11)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 43
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Busca los embarques de la fecha seleccionada")
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "F. fin carga"
        Me.DataGridTextBoxColumn1.MappingName = "HFinalDescarga"
        Me.DataGridTextBoxColumn1.Width = 125
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Factura"
        Me.DataGridTextBoxColumn2.MappingName = "Factura"
        Me.DataGridTextBoxColumn2.Width = 75
        '
        'Grid
        '
        Me.Grid.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Grid.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.Grid.CaptionText = "Lista de entradas por ducto"
        Me.Grid.DataMember = ""
        Me.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.Location = New System.Drawing.Point(0, 43)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.Size = New System.Drawing.Size(792, 328)
        Me.Grid.TabIndex = 42
        Me.Grid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.ToolTip1.SetToolTip(Me.Grid, "Muestra la información relevante de las entradas por ducto")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.Grid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Consecutivo"
        Me.DataGridTextBoxColumn3.MappingName = "Ducto"
        Me.DataGridTextBoxColumn3.Width = 68
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "F. inicio carga"
        Me.DataGridTextBoxColumn4.MappingName = "HinicioDescarga"
        Me.DataGridTextBoxColumn4.Width = 125
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Empresa destino"
        Me.DataGridTextBoxColumn6.MappingName = "Nombre"
        Me.DataGridTextBoxColumn6.Width = 200
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Litros PEMEX"
        Me.DataGridTextBoxColumn7.MappingName = "LitrosPemex"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = "n1"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Kilos PEMEX"
        Me.DataGridTextBoxColumn8.MappingName = "KilosPemex"
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Contenedor de gas"
        Me.DataGridTextBoxColumn9.MappingName = "Tanque"
        Me.DataGridTextBoxColumn9.Width = 220
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Status"
        Me.DataGridTextBoxColumn10.MappingName = "Status"
        Me.DataGridTextBoxColumn10.Width = 65
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.ToolTipText = "Modificar un registro de entrada por ducto"
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(336, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "Fecha inicial:"
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(529, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Fecha final:"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFInicio.Location = New System.Drawing.Point(422, 11)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(100, 21)
        Me.dtpFInicio.TabIndex = 39
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'btnMedicion
        '
        Me.btnMedicion.ImageIndex = 8
        Me.btnMedicion.Text = "M&edición"
        Me.btnMedicion.ToolTipText = "Actualiza los costos del embarque seleccionado"
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 5
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.ToolBarButton1, Me.btnMedicion, Me.ToolBarButton2, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(792, 39)
        Me.BarraBotones.TabIndex = 40
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.ToolTipText = "Agregar una entrada por ducto"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(232, 11)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 44
        '
        'frmConsultaDucto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(792, 374)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBuscar, Me.dtpFFin, Me.Grid, Me.Label1, Me.Label2, Me.dtpFInicio, Me.BarraBotones, Me.btnCerrar2})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmConsultaDucto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de entradas por ducto"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Cargo los datos de los embarques registrados al DataGrid
    Private Sub CargarDatos()
        Grid.DataSource = Nothing

        Dim oConsultaDucto As New PortatilClasses.Catalogo.cConsultaDucto(0, 0, dtpFInicio.Value.Date, dtpFFin.Value.Date)
        Grid.DataSource = oConsultaDucto.dtTable
        oConsultaDucto = Nothing
    End Sub

    ' Carga la pantalla de registrar un embarque
    Private Sub CargarRegistrar()
        Dim oDucto As New frmDucto()
        oDucto.Text = "Entradas por ducto - [Agregar]"
        oDucto.Operacion = "Agregar"
        oDucto.ShowDialog()
    End Sub

    ' Carga la pantalla para la modificación del embarque seleccionado
    Private Sub CargarModificar()
        Dim oDucto As New frmDucto()
        If Grid.VisibleRowCount > 0 Then
            If CType(Grid.Item(Grid.CurrentRowIndex, 8), String) = "ACTIVO" Then
                oDucto.Text = "Entradas por ducto - [Modificar]"
                oDucto.Operacion = "Modificar"
                oDucto.Ducto = CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer)
                oDucto.ShowDialog()
                If oDucto.Ducto = 0 Then
                    CargarDatos()
                End If
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub CargarMedicion()
        Dim oMedicion As New frmMedicionPCFlujo()
        If Grid.VisibleRowCount > 0 Then
            If CType(Grid.Item(Grid.CurrentRowIndex, 8), String) = "ACTIVO" Then
                oMedicion.Ducto = CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer)
                oMedicion.ShowDialog()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BarraBotones_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles BarraBotones.ButtonClick
        Select Case BarraBotones.Buttons.IndexOf(e.Button)
            Case 0
                CargarRegistrar()
            Case 1
                CargarModificar()
            Case 3
                CargarMedicion()
            Case 5
                Close()
        End Select
    End Sub

    Private Sub frmConsultaDucto_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub dtpFFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFFin.KeyDown, dtpFInicio.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    '  Valida las fechas validas
    Private Sub dtpFInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFInicio.TextChanged, dtpFFin.TextChanged
        dtpFFin.MinDate = dtpFInicio.Value.Date
    End Sub

    Private Sub frmConsultaDucto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Refresh()
        CargarDatos()
        ' Habilita los privilegio del usuario
        BarraBotones.Buttons.Item(0).Enabled = GLOBAl_AgregarDucto
        BarraBotones.Buttons.Item(1).Enabled = GLOBAL_ModificarDucto
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
        ActiveControl = Grid
    End Sub
End Class
