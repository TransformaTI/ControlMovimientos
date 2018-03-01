Imports System.Collections.Generic

' Muestra los embarques registrados por fecha, ene sta forma podemos registrar un embarque, modificar y actualizar
' los costo del embarque, por default muestra los embarque del día en curso

Public Class frmConsultaEmbarque
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
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents Grid As System.Windows.Forms.DataGrid
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCosto As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents BarraBotones As System.Windows.Forms.ToolBar
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnVerGuias As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnReporte As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaEmbarque))
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.Grid = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.BarraBotones = New System.Windows.Forms.ToolBar()
        Me.btnCosto = New System.Windows.Forms.ToolBarButton()
        Me.btnReporte = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.dtpFInicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnVerGuias = New System.Windows.Forms.ToolBarButton()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.Grid.CaptionText = "Lista de embarques"
        Me.Grid.DataMember = ""
        Me.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.Location = New System.Drawing.Point(0, 40)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.Size = New System.Drawing.Size(792, 328)
        Me.Grid.TabIndex = 1
        Me.Grid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.ToolTip1.SetToolTip(Me.Grid, "Muestra la información relevante de los embarques")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.Grid
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn10})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Consecutivo"
        Me.DataGridTextBoxColumn2.MappingName = "Embarque"
        Me.DataGridTextBoxColumn2.Width = 68
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "F. embarque"
        Me.DataGridTextBoxColumn1.MappingName = "FEmbarque"
        Me.DataGridTextBoxColumn1.Width = 75
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "F. recepción"
        Me.DataGridTextBoxColumn3.MappingName = "FREcepcion"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Embarque"
        Me.DataGridTextBoxColumn4.MappingName = "NumeroEmbarque"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Empresa a facturar"
        Me.DataGridTextBoxColumn5.MappingName = "CorporativoF"
        Me.DataGridTextBoxColumn5.Width = 200
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
        Me.DataGridTextBoxColumn7.HeaderText = "Procedencia"
        Me.DataGridTextBoxColumn7.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn7.Width = 150
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
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(712, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 20
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Busca los embarques de la fecha seleccionada")
        '
        'dtpFFin
        '
        Me.dtpFFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFin.Location = New System.Drawing.Point(606, 8)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.Size = New System.Drawing.Size(100, 20)
        Me.dtpFFin.TabIndex = 1
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.ToolTipText = "Agregar un registro de embarque"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "&Modificar"
        Me.btnModificar.ToolTipText = "Modificar un registro de embarque"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 5
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla"
        '
        'BarraBotones
        '
        Me.BarraBotones.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.BarraBotones.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnVerGuias, Me.ToolBarButton1, Me.btnCosto, Me.btnReporte, Me.ToolBarButton2, Me.btnCerrar})
        Me.BarraBotones.ButtonSize = New System.Drawing.Size(53, 35)
        Me.BarraBotones.DropDownArrows = True
        Me.BarraBotones.ImageList = Me.imgLista
        Me.BarraBotones.Location = New System.Drawing.Point(0, 0)
        Me.BarraBotones.Name = "BarraBotones"
        Me.BarraBotones.ShowToolTips = True
        Me.BarraBotones.Size = New System.Drawing.Size(792, 42)
        Me.BarraBotones.TabIndex = 0
        '
        'btnCosto
        '
        Me.btnCosto.ImageIndex = 7
        Me.btnCosto.Name = "btnCosto"
        Me.btnCosto.Text = "C&osto"
        Me.btnCosto.ToolTipText = "Actualiza los costos del embarque seleccionado"
        '
        'btnReporte
        '
        Me.btnReporte.ImageIndex = 4
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.ToolTipText = "Exporte reporte de embarques a excell"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Name = "ToolBarButton2"
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(232, 8)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(8, 8)
        Me.btnCerrar2.TabIndex = 22
        '
        'dtpFInicio
        '
        Me.dtpFInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFInicio.Location = New System.Drawing.Point(422, 8)
        Me.dtpFInicio.Name = "dtpFInicio"
        Me.dtpFInicio.Size = New System.Drawing.Size(100, 21)
        Me.dtpFInicio.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(529, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Fecha final:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(336, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 38
        Me.Label1.Text = "Fecha inicial:"
        '
        'btnVerGuias
        '
        Me.btnVerGuias.ImageIndex = 2
        Me.btnVerGuias.Name = "btnVerGuias"
        Me.btnVerGuias.Text = "&Guías"
        Me.btnVerGuias.ToolTipText = "Ver guías de embarque"
        '
        'frmConsultaEmbarque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(792, 374)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpFInicio)
        Me.Controls.Add(Me.dtpFFin)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.BarraBotones)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaEmbarque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de embarques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    ' Cargo los datos de los embarques registrados al DataGrid
    Private Sub CargarDatos()
        Grid.DataSource = Nothing

        Dim oConsultaEmbarque As PortatilClasses.Catalogo.cConsultaEmbarque
        If GLOBAL_VerTodosAlmacenes Then
            oConsultaEmbarque = New PortatilClasses.Catalogo.cConsultaEmbarque(0, 0, dtpFInicio.Value.Date, dtpFFin.Value.Date)
        Else
            oConsultaEmbarque = New PortatilClasses.Catalogo.cConsultaEmbarque(1, GLOBAL_Celula, dtpFInicio.Value.Date, dtpFFin.Value.Date)
        End If

        Grid.DataSource = oConsultaEmbarque.dtTable
        oConsultaEmbarque = Nothing
    End Sub

    ' Carga la pantalla de registrar un embarque
    Private Sub CargarRegistrar()
        Dim oEmbarque As New frmEmbarque()
        oEmbarque.Text = "Embarque - [Agregar]"
        oEmbarque.Operacion = "Agregar"
        oEmbarque.ShowDialog()
    End Sub

    ' Carga la pantalla para la modificación del embarque seleccionado
    Private Sub CargarModificar()
        Dim oEmbarque As New frmEmbarque()
        If Grid.VisibleRowCount > 0 Then
            If CType(Grid.Item(Grid.CurrentRowIndex, 9), String) = "ACTIVO" Then
                oEmbarque.Text = "Embarque - [Modificar]"
                oEmbarque.Operacion = "Modificar"
                oEmbarque.Embarque = CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer)
                oEmbarque.ShowDialog()
                If oEmbarque.Embarque = 0 Then
                    CargarDatos()
                End If
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Carga la pantalla para registrar el costo del embarque
    Private Sub CargarRegistrarCosto()
        If Grid.VisibleRowCount > 0 Then
            Dim oEmbarqueCosto As New frmEmbarqueCosto(CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer))
            oEmbarqueCosto.ShowDialog()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Carga la pantalla de registrar un embarque
    Private Sub VerGuiasEmbarques()
        If Grid.VisibleRowCount > 0 Then
            Dim frmVisualizador As New GuardarArchivos.frmVisualizador()
            Dim oGuiaEmbarque As New GuardarArchivos.GuiaEmbarqueMetodos()
            Dim _lstGuiaEmbarques As List(Of GuardarArchivos.GuiaEmbarqueMetodos)

            oGuiaEmbarque.Conexion = GLOBAL_Conexion
            oGuiaEmbarque.Embarque = CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer)
            _lstGuiaEmbarques = oGuiaEmbarque.Lectura()

            frmVisualizador.Embarque = CType(Grid.Item(Grid.CurrentRowIndex, 0), Integer)
            frmVisualizador.lstGuiaEmbarques = _lstGuiaEmbarques
            frmVisualizador.Text = "Guías de embarque"
            frmVisualizador.SoloConsulta = True
            frmVisualizador.ShowDialog()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Evento del control ToolBar1 se activa la dar clic sobre cualquier botón de la barra
    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) _
    Handles BarraBotones.ButtonClick
        Select Case BarraBotones.Buttons.IndexOf(e.Button)
            Case 0
                CargarRegistrar()
            Case 1
                CargarModificar()
            Case 2
                VerGuiasEmbarques()
            Case 4
                CargarRegistrarCosto()
            Case 5
                Cursor = Cursors.WaitCursor
                Dim oReportes As New ExportarAExcel.ReporteEmbarques(GLOBAL_Usuario, GLOBAL_Password, dtpFInicio.Value, dtpFFin.Value, GLOBAL_ConString)
                oReportes.GeneraArchivo()
                Cursor = Cursors.Default
            Case 7
                Close()
        End Select
    End Sub
    ' Evento de la forma, habilita los privilegios de los usuarios
    Private Sub frmConsultaEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Refresh()
        CargarDatos()
        ' Habilita los privilegio del usuario
        BarraBotones.Buttons.Item(0).Enabled = GLOBAL_CapEmbarque
        BarraBotones.Buttons.Item(1).Enabled = GLOBAL_ModEmbarque
        'If GLOBAL_BasculaInstalada = "1" Then
        '    BarraBotones.Buttons.Item(0).Enabled = False
        'End If
    End Sub

    ' Carga los datos en el DBGrid de la fecha seleccionada
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos()
        ActiveControl = Grid
    End Sub

    Private Sub frmConsultaEmbarque_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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
End Class

