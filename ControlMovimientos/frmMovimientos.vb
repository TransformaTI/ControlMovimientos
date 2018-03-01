' Muestra los movimientos realizados a un amlacén, dependiendod e la configuración podemos carga la
' forma con las entradas o cargar las salidas de los movimientos dependiendo del valor de la variable
' TipoMovimiento (Entrada o Salida)

'Modifico: Claudia Aurora García Patiño
'Fecha: 20/02/2006
'Motivo: Se agrego la impresión de ticket para plantas
'Identificador de cambios: 20060220CAGP$002

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frmMovimientos
    Inherits System.Windows.Forms.Form

    Public TipoMovimiento As String
    Public Almacen As Integer
    Friend WithEvents tbbVisualizar As System.Windows.Forms.ToolBarButton

    Private Titulo As String

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Private _LogonInfo As TableLogOnInfo

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
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgMovimiento As System.Windows.Forms.DataGrid
    Friend WithEvents dtpFFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents tbbCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents muImprimir As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientos))
        Me.dgMovimiento = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.tbbCancelar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbImprimir = New System.Windows.Forms.ToolBarButton()
        Me.muImprimir = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.tbbVisualizar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFFin = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinicio = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        CType(Me.dgMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgMovimiento
        '
        Me.dgMovimiento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMovimiento.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgMovimiento.CaptionText = "Movimientos"
        Me.dgMovimiento.DataMember = ""
        Me.dgMovimiento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgMovimiento.Location = New System.Drawing.Point(0, 47)
        Me.dgMovimiento.Name = "dgMovimiento"
        Me.dgMovimiento.ReadOnly = True
        Me.dgMovimiento.Size = New System.Drawing.Size(931, 386)
        Me.dgMovimiento.TabIndex = 29
        Me.dgMovimiento.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.ToolTip1.SetToolTip(Me.dgMovimiento, "Muestra los movimientos del almacén seleccionado en la fecha especificada")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgMovimiento
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Consecutivo"
        Me.DataGridTextBoxColumn1.MappingName = "MovimientoAlmacen"
        Me.DataGridTextBoxColumn1.Width = 70
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Format = ""
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Movimiento"
        Me.DataGridTextBoxColumn3.MappingName = "TipoMovimientoAlmacen"
        Me.DataGridTextBoxColumn3.Width = 160
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Folio"
        Me.DataGridTextBoxColumn9.MappingName = "NDocumento"
        Me.DataGridTextBoxColumn9.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Fecha mov."
        Me.DataGridTextBoxColumn4.MappingName = "FMovimiento"
        Me.DataGridTextBoxColumn4.Width = 75
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "n0"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn5.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn5.Width = 70
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Producto"
        Me.DataGridTextBoxColumn6.MappingName = "Producto"
        Me.DataGridTextBoxColumn6.Width = 150
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "n1"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Kilos"
        Me.DataGridTextBoxColumn7.MappingName = "Kilos"
        Me.DataGridTextBoxColumn7.Width = 75
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "n2"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Litros"
        Me.DataGridTextBoxColumn8.MappingName = "Litros"
        Me.DataGridTextBoxColumn8.Width = 75
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Status"
        Me.DataGridTextBoxColumn2.MappingName = "Status"
        Me.DataGridTextBoxColumn2.Width = 65
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.MappingName = "AlmacenGas2"
        Me.DataGridTextBoxColumn10.Width = 250
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Tipo"
        Me.DataGridTextBoxColumn11.MappingName = "TipoMov"
        Me.DataGridTextBoxColumn11.Width = 50
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
        Me.imgLista.Images.SetKeyName(8, "")
        Me.imgLista.Images.SetKeyName(9, "")
        Me.imgLista.Images.SetKeyName(10, "")
        Me.imgLista.Images.SetKeyName(11, "")
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbCancelar, Me.tbbSeparador1, Me.tbbImprimir, Me.tbbVisualizar, Me.tbbSeparador2, Me.tbbRefrescar, Me.tbbSeparador3, Me.tbbCerrar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(53, 35)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgLista
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(933, 42)
        Me.ToolBar1.TabIndex = 30
        '
        'tbbCancelar
        '
        Me.tbbCancelar.ImageIndex = 1
        Me.tbbCancelar.Name = "tbbCancelar"
        Me.tbbCancelar.Text = "Cancelar"
        Me.tbbCancelar.ToolTipText = "Cancelación del movimiento seleccionado"
        '
        'tbbSeparador1
        '
        Me.tbbSeparador1.Name = "tbbSeparador1"
        Me.tbbSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbImprimir
        '
        Me.tbbImprimir.ImageIndex = 4
        Me.tbbImprimir.Name = "tbbImprimir"
        Me.tbbImprimir.Text = "Imprimir"
        Me.tbbImprimir.ToolTipText = "Impresión del movimiento seleccionado"
        '
        'muImprimir
        '
        Me.muImprimir.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "&Ticket Plantas"
        '
        'tbbVisualizar
        '
        Me.tbbVisualizar.DropDownMenu = Me.muImprimir
        Me.tbbVisualizar.ImageIndex = 2
        Me.tbbVisualizar.Name = "tbbVisualizar"
        Me.tbbVisualizar.Text = "Visualizar"
        '
        'tbbSeparador2
        '
        Me.tbbSeparador2.Name = "tbbSeparador2"
        Me.tbbSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 3
        Me.tbbRefrescar.Name = "tbbRefrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refresca la información mostrada"
        '
        'tbbSeparador3
        '
        Me.tbbSeparador3.Name = "tbbSeparador3"
        Me.tbbSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 5
        Me.tbbCerrar.Name = "tbbCerrar"
        Me.tbbCerrar.Text = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Salir de la aplicación"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(837, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 27)
        Me.btnBuscar.TabIndex = 2
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Consulta los movimientos de las fechas seleccionadas")
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(395, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Fecha inicial:"
        '
        'dtpFFin
        '
        Me.dtpFFin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFFin.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFFin.Location = New System.Drawing.Point(712, 9)
        Me.dtpFFin.Name = "dtpFFin"
        Me.dtpFFin.Size = New System.Drawing.Size(118, 21)
        Me.dtpFFin.TabIndex = 1
        '
        'dtpFinicio
        '
        Me.dtpFinicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFinicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFinicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinicio.Location = New System.Drawing.Point(496, 9)
        Me.dtpFinicio.Name = "dtpFinicio"
        Me.dtpFinicio.Size = New System.Drawing.Size(118, 21)
        Me.dtpFinicio.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(622, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Fecha final:"
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(282, 9)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(10, 10)
        Me.btnCerrar2.TabIndex = 37
        '
        'frmMovimientos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(933, 440)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpFinicio)
        Me.Controls.Add(Me.dtpFFin)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.dgMovimiento)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmMovimientos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmMovimientos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    Private Sub ImprimirPedidos(ByVal MovimientoAlmacen As Integer)
        Dim oCargaPedido As New PortatilClasses.Catalogo.cCargaPedido(2, 0, MovimientoAlmacen, 0, 0)
        While oCargaPedido.drReader.Read
            Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionPedido.rpt", GLOBAL_Servidor, _
                                GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            oReporte.ListaParametros.Add(CType(oCargaPedido.drReader("PedidoPortatil"), Integer))
            oReporte.ListaParametros.Add(CType(oCargaPedido.drReader("PedidoPortatil"), Integer))
            oReporte.ListaParametros.Add(CType(oCargaPedido.drReader("PedidoPortatil"), Integer))

            oReporte.ShowDialog()
        End While
        oCargaPedido.CerrarConexion()
    End Sub

    ' Muestra el reporte correspondiente al movimiento seleccionado, no s epueden imprimir los movimientos
    ' INACTIVOS
    ' 20060220CAGP$002 /I
    Private Sub ImprimirTicketPlantas(ByVal Tipo As Short, ByVal MovimientoAlmacen As Integer)
        If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 8), String) <> "INACTIVO" Then
            'If Tipo = 1 Or Tipo = 2 Then
            '    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketCarga.rpt", GLOBAL_Servidor, _
            '                        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    'oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ListaParametros.Add(2)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ShowDialog()
            'End If
            If Tipo = 3 Or Tipo = 4 Or Tipo = 5 Or Tipo = 6 Or Tipo = 28 Or Tipo = 29 Or Tipo = 30 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketTrasladoFisico.rpt", _
                                    GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(3)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
            'If Tipo = 7 Or Tipo = 8 Then
            '    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketResguardo.rpt", GLOBAL_Servidor, _
            '                        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ShowDialog()
            'End If
            'If Tipo = 10 Or Tipo = 12 Or Tipo = 13 Or Tipo = 14 Then
            '    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketTraspaso.rpt", _
            '                        GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ShowDialog()
            'End If
            'If Tipo = 11 Then
            '    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacion.rpt", GLOBAL_Servidor, _
            '                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ListaParametros.Add(2)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ListaParametros.Add(3)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ShowDialog()
            'End If
            'If Tipo = 26 Then
            '    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketConsumo.rpt", _
            '                        GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
            '    oReporte.ListaParametros.Add(Configuracion)
            '    oReporte.ListaParametros.Add(MovimientoAlmacen)
            '    oReporte.ShowDialog()
            'End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(18, Me.Text)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ImprimirTicketPlantas()
        ' Impresión de los movimientos en los reportes correspondientes
        If dgMovimiento.VisibleRowCount > 0 Then
            ImprimirTicketPlantas((CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 10), Short)), _
                     (CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 0), Integer)))
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' 20060220CAGP$002 /F

    Private Function PuedeCancelar() As Boolean
        Dim Resultado As Boolean = False
        Dim Tipo As Integer = CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 10), Short)
        Select Case Tipo
            Case 1, 2, 3, 4, 7, 8, 9, 12, 16, 17, 25, 26, 28, 29
                Resultado = GLOBAL_Cancelacion26
            Case 5, 6, 13, 14
                Resultado = GLOBAL_Cancelacion27
            Case 10, 15
                Resultado = GLOBAL_Cancelacion28
            Case 11, 23, 24
                Resultado = GLOBAL_Cancelacion29
            Case 18, 19
                Resultado = GLOBAL_Cancelacion30
            Case 20, 21, 22, 27
                Resultado = GLOBAL_Cancelacion31
        End Select
        If Resultado = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(84, "")
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function

    Private Function FechaPermitida(ByVal MovimientoAlmacen As Integer) As Boolean
        Dim Resultado As Boolean = False
        Try
            Dim oMovimientoACancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
            oMovimientoACancelacion.Registrar(1, MovimientoAlmacen, Almacen, 0, GLOBAL_Usuario)
            If oMovimientoACancelacion.MovimientoAlmacen = 1 Then
                Resultado = True
            End If
            oMovimientoACancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de Movimientos" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Resultado = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(85, "")
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function

    Private Function CargaLiquidada(ByVal MovimientoAlmacen As Integer) As Boolean
        Dim Resultado As Boolean = False
        Try
            Dim oMovimientoACancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
            oMovimientoACancelacion.Registrar(2, MovimientoAlmacen, Almacen, 0, GLOBAL_Usuario)
            If oMovimientoACancelacion.MovimientoAlmacen = 1 Then
                Resultado = True
            End If
            oMovimientoACancelacion = Nothing
        Catch exc As Exception
            EventLog.WriteEntry("Cancelacion de Movimientos" & exc.Source, exc.Message, EventLogEntryType.Error)
            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        If Resultado Then
            Dim Mensajes As New PortatilClasses.Mensaje(86, "")
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        Return Resultado
    End Function

    ' Muestra la pantalla para seleccionar la causa de cancelación, despues INACTIVA el movimiento
    ' y actualiza las existencias de los almacenes afectados
    Private Sub CancelarMovimiento(ByVal MovimientoAlmacen As Integer, ByVal Movimiento As String, _
    ByVal Folio As String)
        If PuedeCancelar() Then
            If FechaPermitida(MovimientoAlmacen) Then
                If CargaLiquidada(MovimientoAlmacen) = False Then
                    Dim oCancelacion As New frmCancelacion(7)
                    oCancelacion.Text = "Cancelación del movimiento: " & Movimiento.ToLower & " con folio " & Folio
                    oCancelacion.ShowDialog()
                    If oCancelacion.MCancelacion > 0 Then
                        Cursor = Cursors.WaitCursor
                        Try
                            Dim oMovimientoACancelacion As New PortatilClasses.Consulta.cMovimientoACancelacion()
                            oMovimientoACancelacion.Registrar(0, MovimientoAlmacen, Almacen, oCancelacion.MCancelacion, GLOBAL_Usuario)
                            oMovimientoACancelacion = Nothing
                        Catch exc As Exception
                            'EventLog.WriteEntry("Cancelacion de Movimientos" & exc.Source, exc.Message, EventLogEntryType.Error)
                            MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        Cursor = Cursors.Default
                    End If
                End If
            End If
        End If
    End Sub

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora(ByVal Impresora As String)
        If Impresora = "" Then
            Dim Impresoras As New Printing.PrinterSettings()
            rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
        Else
            rptReporte.PrintOptions.PrinterName = Impresora
        End If
    End Sub

    ' Establece la conexion de los subreportes que esten contenidos en el reporte
    Private Sub OpenSubreport()
        Dim subreportName As String
        Dim subreportObject As SubreportObject
        Dim subreport As New ReportDocument()
        Dim i As Integer

        For i = 0 To rptReporte.ReportDefinition.ReportObjects.Count - 1
            ' Obtener ReportObject por nombre y proyectarlo como SubreportObject.
            If TypeOf (rptReporte.ReportDefinition.ReportObjects.Item(i)) Is SubreportObject Then
                subreportObject = CType(rptReporte.ReportDefinition.ReportObjects.Item(i), CrystalDecisions.CrystalReports.Engine.SubreportObject)
                ' Obtener el nombre de subinforme.
                subreportName = subreportObject.SubreportName
                ' Abrir el subinforme como ReportDocument.
                subreport = rptReporte.OpenSubreport(subreportName)

                For Each _TablaReporte In subreport.Database.Tables
                    _LogonInfo = _TablaReporte.LogOnInfo
                    With _LogonInfo.ConnectionInfo
                        .ServerName = GLOBAL_Servidor
                        .DatabaseName = GLOBAL_BaseDatos
                        .UserID = GLOBAL_Usuario
                        .Password = GLOBAL_Password
                    End With
                    _TablaReporte.ApplyLogOnInfo(_LogonInfo)
                Next
            End If
        Next
    End Sub

    ' Establece y realiza la conexión para cargar la información al reporte
    Public Sub AplicaInfoConexion()
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = GLOBAL_Servidor
                .DatabaseName = GLOBAL_BaseDatos
                .UserID = GLOBAL_Usuario
                .Password = GLOBAL_Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
        OpenSubreport()
    End Sub

    ' Manda al procedimientos los valores de los parametros e imprime el ticket de carga
    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal NombreTicket As String, ByVal Impresora As String)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try            
            rptReporte.Load(GLOBAL_RutaReportes & "\" & NombreTicket)

            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Configuracion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@MovimientoAlmacen")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            AplicaInfoConexion()

            Try
                EstablecerImpresora(Impresora)
                rptReporte.PrintToPrinter(1, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' Manda al procedimientos los valores de los parametros e imprime el ticket de carga
    Private Sub ImprimirReporteCarga(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer, ByVal Impresora As String)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try            
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketCarga.rpt")

            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(0)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Configuracion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(1)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'Configuracion
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(2)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = 2
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(3)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            'MovimientoAlmacen
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item(4)
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = MovimientoAlmacen
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            AplicaInfoConexion()
            Try
                EstablecerImpresora(Impresora)
                rptReporte.PrintToPrinter(1, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Muestra el reporte correspondiente al movimiento seleccionado, no s epueden imprimir los movimientos
    ' INACTIVOS
    Private Sub ImprimirSinVisualizar(ByVal Tipo As Short, ByVal MovimientoAlmacen As Integer, ByVal Configuracion As Integer)
        If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 8), String) <> "INACTIVO" Then
            If Tipo = 1 Or Tipo = 2 Then
                If GLOBAL_EmpresaComisionista = "1" Then
                    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketCargaComision.rpt", GLOBAL_Servidor, _
                                        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)

                    oReporte.ShowDialog()

                    ImprimirPedidos(MovimientoAlmacen)
                Else
                    Dim Impresoras As New Printing.PrinterSettings()
                    pdImprimir.PrinterSettings = Impresoras
                    pdImprimir.UseEXDialog = True
                    Try
                        If pdImprimir.ShowDialog = DialogResult.OK Then
                            ImprimirReporteCarga(Configuracion, MovimientoAlmacen, pdImprimir.PrinterSettings.PrinterName)
                        End If
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                End If
            End If

            If Tipo = 3 Or Tipo = 4 Or Tipo = 5 Or Tipo = 6 Or Tipo = 29 Or Tipo = 30 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketTraslado.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If
            If Tipo = 7 Or Tipo = 8 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketResguardo.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If
            If Tipo = 10 Or Tipo = 12 Or Tipo = 13 Or Tipo = 14 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketTraspaso.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If
            If Tipo = 11 Then
                If GLOBAL_EmpresaComisionista = "1" Then
                    If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 9), String) <> "N/A" Then
                        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionComision.rpt", GLOBAL_Servidor, _
                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                        oReporte.ListaParametros.Add(4)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)

                        oReporte.ShowDialog()
                    Else
                        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionCyC.rpt", GLOBAL_Servidor, _
                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                        'oReporte.ListaParametros.Add(6)
                        'oReporte.ListaParametros.Add(MovimientoAlmacen)
                        'oReporte.ListaParametros.Add(1)
                        'oReporte.ListaParametros.Add(MovimientoAlmacen)
                        'oReporte.ListaParametros.Add(7)
                        'oReporte.ListaParametros.Add(MovimientoAlmacen)
                        'oReporte.ListaParametros.Add(3)
                        'oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(6)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(7)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)                                            
                        oReporte.ListaParametros.Add(3)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(1)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ShowDialog()
                    End If

                Else
                    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacion.rpt", GLOBAL_Servidor, _
                                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                    oReporte.ListaParametros.Add(Configuracion)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(Configuracion)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(3)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ShowDialog()
                End If
            End If

            If Tipo = 20 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketTrasiego.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If

            If Tipo = 26 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketConsumo.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If
            If Tipo = 28 Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                pdImprimir.UseEXDialog = True
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(Configuracion, MovimientoAlmacen, "ReporteTicketReposicionFuga.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(18, Me.Text)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Muestra el reporte correspondiente al movimiento seleccionado, no s epueden imprimir los movimientos
    ' INACTIVOS
    Private Sub Imprimir(ByVal Tipo As Short, ByVal MovimientoAlmacen As Integer, ByVal Configuracion As Integer)
        If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 8), String) <> "INACTIVO" Then
            If Tipo = 1 Or Tipo = 2 Then
                If GLOBAL_EmpresaComisionista = "1" Then
                    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketCargaComision.rpt", GLOBAL_Servidor, _
                                        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)

                    oReporte.ShowDialog()

                    ImprimirPedidos(MovimientoAlmacen)
                Else
                    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketCarga.rpt", GLOBAL_Servidor, _
                                        GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                    oReporte.ListaParametros.Add(Configuracion)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ShowDialog()
                End If

            End If
            If Tipo = 3 Or Tipo = 4 Or Tipo = 5 Or Tipo = 6 Or Tipo = 29 Or Tipo = 30 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketTraslado.rpt", _
                                    GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
            If Tipo = 7 Or Tipo = 8 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketResguardo.rpt", GLOBAL_Servidor, _
                                    GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
            If Tipo = 10 Or Tipo = 12 Or Tipo = 13 Or Tipo = 14 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketTraspaso.rpt", _
                                    GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
            If Tipo = 11 Then
                If GLOBAL_EmpresaComisionista = "1" Then
                    If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 9), String) <> "N/A" Then
                        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionComision.rpt", GLOBAL_Servidor, _
                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                        oReporte.ListaParametros.Add(4)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)

                        oReporte.ShowDialog()
                    Else
                        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacionCyC.rpt", GLOBAL_Servidor, _
                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                        oReporte.ListaParametros.Add(6)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(1)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(7)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ListaParametros.Add(3)
                        oReporte.ListaParametros.Add(MovimientoAlmacen)
                        oReporte.ShowDialog()
                    End If

                Else
                    Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteLiquidacion.rpt", GLOBAL_Servidor, _
                                          GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                    oReporte.ListaParametros.Add(Configuracion)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(Configuracion)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(2)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)
                    oReporte.ListaParametros.Add(3)
                    oReporte.ListaParametros.Add(MovimientoAlmacen)

                    oReporte.ShowDialog()
                End If
            End If
            If Tipo = 26 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketConsumo.rpt", _
                                    GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
            If Tipo = 28 Then
                Dim oReporte As New ReporteDinamicoOaxaca.frmReporte(GLOBAL_RutaReportes, "ReporteTicketReposicionFuga.rpt", _
                                                    GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, False)
                oReporte.ListaParametros.Add(Configuracion)
                oReporte.ListaParametros.Add(MovimientoAlmacen)
                oReporte.ShowDialog()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(18, Me.Text)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Carga los datos al grid dependiendo del tipo de movimeintos ENTRADA o SALIDA
    Private Sub CargarDatos(ByVal FInicio As Date, ByVal FFin As Date)
        Dim oMovimientos As PortatilClasses.Catalogo.cConsultaMovimientos
        Cursor = Cursors.WaitCursor
        dgMovimiento.DataSource = Nothing
        If TipoMovimiento = "ENTRADA" Then
            oMovimientos = New PortatilClasses.Catalogo.cConsultaMovimientos(1, Almacen, FInicio, FFin)
            DataGridTextBoxColumn10.HeaderText = "Almacén origen"
        Else
            oMovimientos = New PortatilClasses.Catalogo.cConsultaMovimientos(2, Almacen, FInicio, FFin)
            DataGridTextBoxColumn10.HeaderText = "Almacén destino"
        End If
        dgMovimiento.DataSource = oMovimientos.dtTable
        oMovimientos = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Inicializa las variables y los controles de la forma
    Private Sub frmMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ActiveControl = dtpFinicio
        dtpFinicio.Value = Now
        dtpFFin.Value = Now
        CargarDatos(dtpFinicio.Value.Date, dtpFFin.Value.Date)
        ' Solo los usuarios con privilegios pueden cancelar movimientos
        ToolBar1.Buttons.Item(0).Enabled = GLOBAL_CancelarMov
        ' Solo los usuarios con privilegios pueden ver los reportes
        ToolBar1.Buttons.Item(2).Enabled = GLOBAL_Reportes
        If GLOBAL_Reportes Then
            If GLOBAL_ImprimitTicketPlantas And GLOBAL_MedicionFisica Then
                ToolBar1.Buttons.Item(3).Style = ToolBarButtonStyle.DropDownButton
            Else
                ToolBar1.Buttons.Item(3).Style = ToolBarButtonStyle.PushButton
            End If
        End If
        Titulo = "Movimientos"
    End Sub

    ' Carga los datos al grid
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargarDatos(dtpFinicio.Value.Date, dtpFFin.Value.Date)
    End Sub

    ' Evento de los controles para pasar de un control a otro por medio del Enter
    Private Sub dtpFFin_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFFin.KeyDown, dtpFinicio.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento que se activa al dar clic a la barra de opciones
    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case ToolBar1.Buttons.IndexOf(e.Button)
            Case 0
                ' Cancelación de los movimientos
                If dgMovimiento.VisibleRowCount > 0 Then
                    If CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 8), String) = "ACTIVO" Then
                        CancelarMovimiento(CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 0), Integer), _
                                           CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 1), String), _
                                           CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 2), String))
                    End If

                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(11)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 2
                ' Impresión de los movimientos en los reportes correspondientes
                If dgMovimiento.VisibleRowCount > 0 Then
                    ImprimirSinVisualizar((CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 10), Short)), _
                             (CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 0), Integer)), 1)
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(11)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 3
                ' Impresión de los movimientos en los reportes correspondientes
                If dgMovimiento.VisibleRowCount > 0 Then
                    Imprimir((CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 10), Short)), _
                             (CType(dgMovimiento.Item(dgMovimiento.CurrentRowIndex, 0), Integer)), 1)
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(11)
                    MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Case 5
                ' Carga los datos al grid
                CargarDatos(dtpFinicio.Value.Date, dtpFFin.Value.Date)
            Case 7
                Close()
        End Select
    End Sub

    ' Valida que la información sea la correcta
    Private Sub dtpFinicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFinicio.TextChanged
        dtpFFin.MinDate = dtpFinicio.Value.Date
    End Sub

    Private Sub frmMovimientos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    '  Valida las fechas validas
    Private Sub dtpFInicial_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFinicio.TextChanged, dtpFFin.TextChanged
        dtpFFin.MinDate = dtpFinicio.Value.Date
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        ImprimirTicketPlantas()     ' 20060220CAGP$002
    End Sub

End Class
