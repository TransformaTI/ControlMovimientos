' Forma principal del modulo de control de movimientos, nos muestra los almacenes de cada celula y sus existencias
' en esta forma podemos realizar los principales movimientos que afectarán directamente las existencias

'Modificó: Carlos Francisco Sánchez Lavariega
'Fecha: 26/11/2005
'Descripción: Se agrego la funcionalidad de las dos nuevas operaciones para que interactuen con los menus de las pantallas
'               del programa de compras(frmProgramaCompras) y ventas(frmProgramaVentas)
'Identificador de cambios: 20051125CFSL#002

'Variable de cambio: 20051203CAGP $000
'Motivo. Se modifico la pantalla de fugas portatil

'Modificó: Claudia García
'Fecha: 02 de Marzo del 2006
'Motivo: Se agrego una operacio
'Identificador: 20060302CAGP$001

Imports SigaMetClasses

Public Class frmPrincipal
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        GLOBAL_Conexion.ConnectionString = GLOBAL_ConString
        Bascula.Globales.GetInstance.ConfiguraModulo(GLOBAL_Conexion, GLOBAL_Usuario, GLOBAL_Password, GLOBAL_Empresa, GLOBAL_Sucursal)
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
    Friend WithEvents mnuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents mnuListaReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAyuda As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAcercaDe As System.Windows.Forms.MenuItem
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbpUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpUsuarioNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpBaseDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuArchivo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCarga As System.Windows.Forms.MenuItem
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgAlmacen As System.Windows.Forms.DataGrid
    Friend WithEvents dgExistencia As System.Windows.Forms.DataGrid
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents sbpDepartamento As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents mnuCambioClave As System.Windows.Forms.MenuItem
    Friend WithEvents mnuParametros As System.Windows.Forms.MenuItem
    Friend WithEvents mnuHerramientas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuKardex As System.Windows.Forms.MenuItem
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents dgStock As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTableStyle3 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents DataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbEntradas As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSalidas As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCarga As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbKardex As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents DataGridTextBoxColumn18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents pnTAlmacenExistencias As PortatilClasses.CrearControl.TipoAlmacenExistencias
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbSeparador4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbTraslado As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuTraslado As System.Windows.Forms.MenuItem
    Friend WithEvents tbbCompras As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuCompras As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBttCompras As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuBttEmbarque As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBttTrasladoCpra As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBttDucto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEmbarque As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTrasladoCpra As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDucto As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVentas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMovimientos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEntradas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalidas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuEResguardo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSReposicion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInventarioInicial As System.Windows.Forms.MenuItem
    Friend WithEvents mnuBascula As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDestinos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTransportadoras As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCiclo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuModificar As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAutoCarburacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsumo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTrasladoVta As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInventarioFisico As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVtaPortatil As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVtaCarburacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReporteFisico As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReporteContable As System.Windows.Forms.MenuItem
    Friend WithEvents mnuReposicionFugas As System.Windows.Forms.MenuItem
    Friend WithEvents cboCelulaPtl As PortatilClasses.Combo.ComboBase
    Friend WithEvents mnuSeparadorMovimientos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSeparadorCompras As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProgramaCompra As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSeparadorVentas As System.Windows.Forms.MenuItem
    Friend WithEvents mnuProgramaVenta As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDevolucion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuKilometraje As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents mnuPreliquidacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuComisionista As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConfiguracion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuComisiones As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalidaTrasiego As System.Windows.Forms.MenuItem
    Friend WithEvents mnuInventarioFisicoActaCierre As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImportar As System.Windows.Forms.MenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.mnuPrincipal = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuArchivo = New System.Windows.Forms.MenuItem()
        Me.mnuCarga = New System.Windows.Forms.MenuItem()
        Me.mnuPreliquidacion = New System.Windows.Forms.MenuItem()
        Me.mnuTraslado = New System.Windows.Forms.MenuItem()
        Me.mnuBascula = New System.Windows.Forms.MenuItem()
        Me.mnuCiclo = New System.Windows.Forms.MenuItem()
        Me.mnuModificar = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuKilometraje = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.mnuSalir = New System.Windows.Forms.MenuItem()
        Me.mnuMovimientos = New System.Windows.Forms.MenuItem()
        Me.mnuEntradas = New System.Windows.Forms.MenuItem()
        Me.mnuEResguardo = New System.Windows.Forms.MenuItem()
        Me.mnuInventarioInicial = New System.Windows.Forms.MenuItem()
        Me.mnuDevolucion = New System.Windows.Forms.MenuItem()
        Me.mnuSalidas = New System.Windows.Forms.MenuItem()
        Me.mnuSReposicion = New System.Windows.Forms.MenuItem()
        Me.mnuAutoCarburacion = New System.Windows.Forms.MenuItem()
        Me.mnuConsumo = New System.Windows.Forms.MenuItem()
        Me.mnuReposicionFugas = New System.Windows.Forms.MenuItem()
        Me.mnuSalidaTrasiego = New System.Windows.Forms.MenuItem()
        Me.mnuSeparadorMovimientos = New System.Windows.Forms.MenuItem()
        Me.mnuInventarioFisico = New System.Windows.Forms.MenuItem()
        Me.mnuInventarioFisicoActaCierre = New System.Windows.Forms.MenuItem()
        Me.mnuCompras = New System.Windows.Forms.MenuItem()
        Me.mnuEmbarque = New System.Windows.Forms.MenuItem()
        Me.mnuTrasladoCpra = New System.Windows.Forms.MenuItem()
        Me.mnuDucto = New System.Windows.Forms.MenuItem()
        Me.mnuSeparadorCompras = New System.Windows.Forms.MenuItem()
        Me.mnuProgramaCompra = New System.Windows.Forms.MenuItem()
        Me.mnuVentas = New System.Windows.Forms.MenuItem()
        Me.mnuVtaPortatil = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mnuTrasladoVta = New System.Windows.Forms.MenuItem()
        Me.mnuVtaCarburacion = New System.Windows.Forms.MenuItem()
        Me.mnuImportar = New System.Windows.Forms.MenuItem()
        Me.mnuSeparadorVentas = New System.Windows.Forms.MenuItem()
        Me.mnuProgramaVenta = New System.Windows.Forms.MenuItem()
        Me.mnuListaReportes = New System.Windows.Forms.MenuItem()
        Me.mnuKardex = New System.Windows.Forms.MenuItem()
        Me.mnuReporteFisico = New System.Windows.Forms.MenuItem()
        Me.mnuReporteContable = New System.Windows.Forms.MenuItem()
        Me.mnuReportes = New System.Windows.Forms.MenuItem()
        Me.mnuCatalogos = New System.Windows.Forms.MenuItem()
        Me.mnuDestinos = New System.Windows.Forms.MenuItem()
        Me.mnuTransportadoras = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.mnuComisionista = New System.Windows.Forms.MenuItem()
        Me.mnuConfiguracion = New System.Windows.Forms.MenuItem()
        Me.mnuComisiones = New System.Windows.Forms.MenuItem()
        Me.mnuHerramientas = New System.Windows.Forms.MenuItem()
        Me.mnuCambioClave = New System.Windows.Forms.MenuItem()
        Me.mnuParametros = New System.Windows.Forms.MenuItem()
        Me.mnuAyuda = New System.Windows.Forms.MenuItem()
        Me.mnuAcercaDe = New System.Windows.Forms.MenuItem()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.sbpUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.sbpUsuarioNombre = New System.Windows.Forms.StatusBarPanel()
        Me.sbpDepartamento = New System.Windows.Forms.StatusBarPanel()
        Me.sbpServidor = New System.Windows.Forms.StatusBarPanel()
        Me.sbpBaseDatos = New System.Windows.Forms.StatusBarPanel()
        Me.sbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.tbbEntradas = New System.Windows.Forms.ToolBarButton()
        Me.mnuBttCompras = New System.Windows.Forms.ContextMenu()
        Me.mnuBttEmbarque = New System.Windows.Forms.MenuItem()
        Me.mnuBttTrasladoCpra = New System.Windows.Forms.MenuItem()
        Me.mnuBttDucto = New System.Windows.Forms.MenuItem()
        Me.tbbSalidas = New System.Windows.Forms.ToolBarButton()
        Me.tbbCarga = New System.Windows.Forms.ToolBarButton()
        Me.tbbTraslado = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCompras = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbKardex = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.tbbSeparador4 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.dgAlmacen = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn19 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.dgExistencia = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle3 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.dgStock = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboCelulaPtl = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.pnTAlmacenExistencias = New PortatilClasses.CrearControl.TipoAlmacenExistencias(Me.components)
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpBaseDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAlmacen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgExistencia, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuArchivo, Me.mnuMovimientos, Me.mnuCompras, Me.mnuVentas, Me.mnuListaReportes, Me.mnuCatalogos, Me.mnuComisionista, Me.mnuHerramientas, Me.mnuAyuda})
        '
        'mnuArchivo
        '
        Me.mnuArchivo.Index = 0
        Me.mnuArchivo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCarga, Me.mnuPreliquidacion, Me.mnuTraslado, Me.mnuBascula, Me.MenuItem1, Me.mnuKilometraje, Me.MenuItem7, Me.mnuSalir})
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuCarga
        '
        Me.mnuCarga.Index = 0
        Me.mnuCarga.Text = "&Carga"
        '
        'mnuPreliquidacion
        '
        Me.mnuPreliquidacion.Index = 1
        Me.mnuPreliquidacion.Text = "Preliquidacion creditos portátil"
        '
        'mnuTraslado
        '
        Me.mnuTraslado.Index = 2
        Me.mnuTraslado.Text = "&Traslado"
        '
        'mnuBascula
        '
        Me.mnuBascula.Index = 3
        Me.mnuBascula.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCiclo, Me.mnuModificar})
        Me.mnuBascula.Text = "&Bascula"
        Me.mnuBascula.Visible = False
        '
        'mnuCiclo
        '
        Me.mnuCiclo.Index = 0
        Me.mnuCiclo.Text = "&Ciclo estacionario"
        '
        'mnuModificar
        '
        Me.mnuModificar.Index = 1
        Me.mnuModificar.Text = "&Modificar ciclo"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 4
        Me.MenuItem1.Text = "-"
        '
        'mnuKilometraje
        '
        Me.mnuKilometraje.Index = 5
        Me.mnuKilometraje.Text = "&Kilometraje"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 6
        Me.MenuItem7.Text = "-"
        '
        'mnuSalir
        '
        Me.mnuSalir.Index = 7
        Me.mnuSalir.Text = "&Salir"
        '
        'mnuMovimientos
        '
        Me.mnuMovimientos.Index = 1
        Me.mnuMovimientos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEntradas, Me.mnuSalidas, Me.mnuSeparadorMovimientos, Me.mnuInventarioFisico, Me.mnuInventarioFisicoActaCierre})
        Me.mnuMovimientos.Text = "&Movimientos"
        '
        'mnuEntradas
        '
        Me.mnuEntradas.Index = 0
        Me.mnuEntradas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEResguardo, Me.mnuInventarioInicial, Me.mnuDevolucion})
        Me.mnuEntradas.Text = "&Entradas"
        '
        'mnuEResguardo
        '
        Me.mnuEResguardo.Index = 0
        Me.mnuEResguardo.Text = "Por& resguardo"
        '
        'mnuInventarioInicial
        '
        Me.mnuInventarioInicial.Index = 1
        Me.mnuInventarioInicial.Text = "Por &inventario inicial"
        '
        'mnuDevolucion
        '
        Me.mnuDevolucion.Index = 2
        Me.mnuDevolucion.Text = "Por &devolución"
        Me.mnuDevolucion.Visible = False
        '
        'mnuSalidas
        '
        Me.mnuSalidas.Index = 1
        Me.mnuSalidas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuSReposicion, Me.mnuAutoCarburacion, Me.mnuConsumo, Me.mnuReposicionFugas, Me.mnuSalidaTrasiego})
        Me.mnuSalidas.Text = "&Salidas"
        '
        'mnuSReposicion
        '
        Me.mnuSReposicion.Index = 0
        Me.mnuSReposicion.Text = "Por &reposición"
        '
        'mnuAutoCarburacion
        '
        Me.mnuAutoCarburacion.Index = 1
        Me.mnuAutoCarburacion.Text = "Por &autocarburación"
        '
        'mnuConsumo
        '
        Me.mnuConsumo.Index = 2
        Me.mnuConsumo.Text = "Por &consumo"
        '
        'mnuReposicionFugas
        '
        Me.mnuReposicionFugas.Index = 3
        Me.mnuReposicionFugas.Text = "Por reposición de &fugas portátil"
        '
        'mnuSalidaTrasiego
        '
        Me.mnuSalidaTrasiego.Index = 4
        Me.mnuSalidaTrasiego.Text = "Por &trasiego"
        '
        'mnuSeparadorMovimientos
        '
        Me.mnuSeparadorMovimientos.Index = 2
        Me.mnuSeparadorMovimientos.Text = "-"
        '
        'mnuInventarioFisico
        '
        Me.mnuInventarioFisico.Index = 3
        Me.mnuInventarioFisico.Text = "&Inventario físico"
        '
        'mnuInventarioFisicoActaCierre
        '
        Me.mnuInventarioFisicoActaCierre.Index = 4
        Me.mnuInventarioFisicoActaCierre.Text = "Inventario fisico por acta cierre"
        '
        'mnuCompras
        '
        Me.mnuCompras.Index = 2
        Me.mnuCompras.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEmbarque, Me.mnuTrasladoCpra, Me.mnuDucto, Me.mnuSeparadorCompras, Me.mnuProgramaCompra})
        Me.mnuCompras.Text = "&Compras"
        '
        'mnuEmbarque
        '
        Me.mnuEmbarque.Index = 0
        Me.mnuEmbarque.Text = "Por &embarque"
        '
        'mnuTrasladoCpra
        '
        Me.mnuTrasladoCpra.Index = 1
        Me.mnuTrasladoCpra.Text = "Por &traslado compra filial"
        '
        'mnuDucto
        '
        Me.mnuDucto.Index = 2
        Me.mnuDucto.Text = "Por &ducto"
        '
        'mnuSeparadorCompras
        '
        Me.mnuSeparadorCompras.Index = 3
        Me.mnuSeparadorCompras.Text = "-"
        '
        'mnuProgramaCompra
        '
        Me.mnuProgramaCompra.Index = 4
        Me.mnuProgramaCompra.Text = "&Programa de compras"
        '
        'mnuVentas
        '
        Me.mnuVentas.Index = 3
        Me.mnuVentas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuVtaPortatil, Me.MenuItem5, Me.mnuTrasladoVta, Me.mnuVtaCarburacion, Me.mnuImportar, Me.mnuSeparadorVentas, Me.mnuProgramaVenta})
        Me.mnuVentas.Text = "&Ventas"
        '
        'mnuVtaPortatil
        '
        Me.mnuVtaPortatil.Index = 0
        Me.mnuVtaPortatil.Text = "Por &liquidación portátil"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "Por &traspaso a filial"
        '
        'mnuTrasladoVta
        '
        Me.mnuTrasladoVta.Index = 2
        Me.mnuTrasladoVta.Text = "Por t&raslado a filial"
        '
        'mnuVtaCarburacion
        '
        Me.mnuVtaCarburacion.Index = 3
        Me.mnuVtaCarburacion.Text = "Por &vta. carburación"
        '
        'mnuImportar
        '
        Me.mnuImportar.Index = 4
        Me.mnuImportar.Text = "&Importar"
        '
        'mnuSeparadorVentas
        '
        Me.mnuSeparadorVentas.Index = 5
        Me.mnuSeparadorVentas.Text = "-"
        '
        'mnuProgramaVenta
        '
        Me.mnuProgramaVenta.Index = 6
        Me.mnuProgramaVenta.Text = "&Programa de ventas"
        '
        'mnuListaReportes
        '
        Me.mnuListaReportes.Index = 4
        Me.mnuListaReportes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuKardex, Me.mnuReporteFisico, Me.mnuReporteContable, Me.mnuReportes})
        Me.mnuListaReportes.Text = "&Reportes"
        '
        'mnuKardex
        '
        Me.mnuKardex.Index = 0
        Me.mnuKardex.Text = "&Kardex"
        Me.mnuKardex.Visible = False
        '
        'mnuReporteFisico
        '
        Me.mnuReporteFisico.Index = 1
        Me.mnuReporteFisico.Text = "Inv. físico"
        '
        'mnuReporteContable
        '
        Me.mnuReporteContable.Index = 2
        Me.mnuReporteContable.Text = "Inv. contable"
        '
        'mnuReportes
        '
        Me.mnuReportes.Index = 3
        Me.mnuReportes.Text = "&Reportes..."
        '
        'mnuCatalogos
        '
        Me.mnuCatalogos.Index = 5
        Me.mnuCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuDestinos, Me.mnuTransportadoras, Me.MenuItem3, Me.MenuItem4, Me.MenuItem6})
        Me.mnuCatalogos.Text = "C&atalogos"
        '
        'mnuDestinos
        '
        Me.mnuDestinos.Index = 0
        Me.mnuDestinos.Text = "&Destinos"
        '
        'mnuTransportadoras
        '
        Me.mnuTransportadoras.Index = 1
        Me.mnuTransportadoras.Text = "&Transportadoras"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "&Almacén de gas"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "Tan&que físico"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 4
        Me.MenuItem6.Text = "&Corporativo"
        '
        'mnuComisionista
        '
        Me.mnuComisionista.Index = 6
        Me.mnuComisionista.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConfiguracion, Me.mnuComisiones})
        Me.mnuComisionista.Text = "C&omisionistas"
        Me.mnuComisionista.Visible = False
        '
        'mnuConfiguracion
        '
        Me.mnuConfiguracion.Index = 0
        Me.mnuConfiguracion.Text = "&Configuración"
        '
        'mnuComisiones
        '
        Me.mnuComisiones.Index = 1
        Me.mnuComisiones.Text = "Comisiones"
        '
        'mnuHerramientas
        '
        Me.mnuHerramientas.Index = 7
        Me.mnuHerramientas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCambioClave, Me.mnuParametros})
        Me.mnuHerramientas.Text = "&Herramientas"
        '
        'mnuCambioClave
        '
        Me.mnuCambioClave.Index = 0
        Me.mnuCambioClave.Text = "&Cambio de contraseña"
        '
        'mnuParametros
        '
        Me.mnuParametros.Index = 1
        Me.mnuParametros.Text = "&Parámetros del sistema"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Index = 8
        Me.mnuAyuda.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAcercaDe})
        Me.mnuAyuda.Text = "&?"
        '
        'mnuAcercaDe
        '
        Me.mnuAcercaDe.Index = 0
        Me.mnuAcercaDe.Text = "&Acerca de..."
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 360)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpUsuario, Me.sbpUsuarioNombre, Me.sbpDepartamento, Me.sbpServidor, Me.sbpBaseDatos, Me.sbpVersion})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(930, 26)
        Me.stbEstatus.TabIndex = 1
        Me.stbEstatus.Text = "StatusBar1"
        '
        'sbpUsuario
        '
        Me.sbpUsuario.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpUsuario.Name = "sbpUsuario"
        '
        'sbpUsuarioNombre
        '
        Me.sbpUsuarioNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpUsuarioNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpUsuarioNombre.Name = "sbpUsuarioNombre"
        Me.sbpUsuarioNombre.Width = 204
        '
        'sbpDepartamento
        '
        Me.sbpDepartamento.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpDepartamento.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpDepartamento.Name = "sbpDepartamento"
        Me.sbpDepartamento.Width = 204
        '
        'sbpServidor
        '
        Me.sbpServidor.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpServidor.Name = "sbpServidor"
        '
        'sbpBaseDatos
        '
        Me.sbpBaseDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpBaseDatos.Name = "sbpBaseDatos"
        '
        'sbpVersion
        '
        Me.sbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.sbpVersion.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpVersion.Name = "sbpVersion"
        Me.sbpVersion.Width = 204
        '
        'ToolBar1
        '
        Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbEntradas, Me.tbbSalidas, Me.tbbCarga, Me.tbbTraslado, Me.tbbSeparador1, Me.tbbCompras, Me.tbbSeparador2, Me.tbbKardex, Me.tbbSeparador3, Me.tbbRefrescar, Me.tbbSeparador4, Me.tbbCerrar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(60, 35)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgLista
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(930, 50)
        Me.ToolBar1.TabIndex = 22
        '
        'tbbEntradas
        '
        Me.tbbEntradas.DropDownMenu = Me.mnuBttCompras
        Me.tbbEntradas.ImageIndex = 9
        Me.tbbEntradas.Name = "tbbEntradas"
        Me.tbbEntradas.Text = "Entradas"
        Me.tbbEntradas.ToolTipText = "Cargar las entradas del almacén"
        '
        'mnuBttCompras
        '
        Me.mnuBttCompras.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuBttEmbarque, Me.mnuBttTrasladoCpra, Me.mnuBttDucto})
        '
        'mnuBttEmbarque
        '
        Me.mnuBttEmbarque.Index = 0
        Me.mnuBttEmbarque.Text = "Por Embarque"
        '
        'mnuBttTrasladoCpra
        '
        Me.mnuBttTrasladoCpra.Index = 1
        Me.mnuBttTrasladoCpra.Text = "Por Traslado Compra Filial"
        '
        'mnuBttDucto
        '
        Me.mnuBttDucto.Index = 2
        Me.mnuBttDucto.Text = "Por Ducto"
        '
        'tbbSalidas
        '
        Me.tbbSalidas.ImageIndex = 8
        Me.tbbSalidas.Name = "tbbSalidas"
        Me.tbbSalidas.Text = "Salidas"
        Me.tbbSalidas.ToolTipText = "Cargar las salidas del almacén"
        '
        'tbbCarga
        '
        Me.tbbCarga.ImageIndex = 10
        Me.tbbCarga.Name = "tbbCarga"
        Me.tbbCarga.Text = "Carga"
        Me.tbbCarga.ToolTipText = "Registrar las cargas portátil"
        '
        'tbbTraslado
        '
        Me.tbbTraslado.ImageIndex = 7
        Me.tbbTraslado.Name = "tbbTraslado"
        Me.tbbTraslado.Text = "Traslado"
        Me.tbbTraslado.ToolTipText = "Registrar los traslados de gas"
        '
        'tbbSeparador1
        '
        Me.tbbSeparador1.Name = "tbbSeparador1"
        Me.tbbSeparador1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCompras
        '
        Me.tbbCompras.DropDownMenu = Me.mnuBttCompras
        Me.tbbCompras.ImageIndex = 11
        Me.tbbCompras.Name = "tbbCompras"
        Me.tbbCompras.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.tbbCompras.Text = "Compras"
        Me.tbbCompras.ToolTipText = "Control de compras realizadas"
        '
        'tbbSeparador2
        '
        Me.tbbSeparador2.Name = "tbbSeparador2"
        Me.tbbSeparador2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbKardex
        '
        Me.tbbKardex.ImageIndex = 0
        Me.tbbKardex.Name = "tbbKardex"
        Me.tbbKardex.Text = "Kardex"
        Me.tbbKardex.ToolTipText = "Muestra las entradas y salidas del almacén seleccionado"
        Me.tbbKardex.Visible = False
        '
        'tbbSeparador3
        '
        Me.tbbSeparador3.Name = "tbbSeparador3"
        Me.tbbSeparador3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 3
        Me.tbbRefrescar.Name = "tbbRefrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Recarga la información visualizada"
        '
        'tbbSeparador4
        '
        Me.tbbSeparador4.Name = "tbbSeparador4"
        Me.tbbSeparador4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 5
        Me.tbbCerrar.Name = "tbbCerrar"
        Me.tbbCerrar.Text = "Cerrar"
        Me.tbbCerrar.ToolTipText = "Salir de la aplicación"
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
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(343, 9)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(235, 20)
        Me.dtpFecha.TabIndex = 26
        '
        'dgAlmacen
        '
        Me.dgAlmacen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAlmacen.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgAlmacen.CaptionText = "Almacenes"
        Me.dgAlmacen.DataMember = ""
        Me.dgAlmacen.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgAlmacen.Location = New System.Drawing.Point(0, 38)
        Me.dgAlmacen.Name = "dgAlmacen"
        Me.dgAlmacen.ReadOnly = True
        Me.dgAlmacen.Size = New System.Drawing.Size(940, 41)
        Me.dgAlmacen.TabIndex = 2
        Me.dgAlmacen.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        Me.ToolTip1.SetToolTip(Me.dgAlmacen, "Muestra los almacenes pertenecientes a la célula seleccionada")
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgAlmacen
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn18, Me.DataGridTextBoxColumn19, Me.DataGridTextBoxColumn10, Me.DataGridTextBoxColumn11, Me.DataGridTextBoxColumn12, Me.DataGridTextBoxColumn13, Me.DataGridTextBoxColumn9, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = ""
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Almacén"
        Me.DataGridTextBoxColumn1.MappingName = "AlmacenGas"
        Me.DataGridTextBoxColumn1.Width = 60
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Descripción"
        Me.DataGridTextBoxColumn2.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn2.Width = 250
        '
        'DataGridTextBoxColumn18
        '
        Me.DataGridTextBoxColumn18.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn18.Format = "n1"
        Me.DataGridTextBoxColumn18.FormatInfo = Nothing
        Me.DataGridTextBoxColumn18.HeaderText = "Total kilos"
        Me.DataGridTextBoxColumn18.MappingName = "TotalKilos"
        Me.DataGridTextBoxColumn18.Width = 75
        '
        'DataGridTextBoxColumn19
        '
        Me.DataGridTextBoxColumn19.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn19.Format = "n2"
        Me.DataGridTextBoxColumn19.FormatInfo = Nothing
        Me.DataGridTextBoxColumn19.HeaderText = "Total litros"
        Me.DataGridTextBoxColumn19.MappingName = "TotalLitros"
        Me.DataGridTextBoxColumn19.Width = 75
        '
        'DataGridTextBoxColumn10
        '
        Me.DataGridTextBoxColumn10.Format = ""
        Me.DataGridTextBoxColumn10.FormatInfo = Nothing
        Me.DataGridTextBoxColumn10.HeaderText = "Tipo de almacén"
        Me.DataGridTextBoxColumn10.MappingName = "TipoAlmacenGas"
        Me.DataGridTextBoxColumn10.Width = 180
        '
        'DataGridTextBoxColumn11
        '
        Me.DataGridTextBoxColumn11.Format = ""
        Me.DataGridTextBoxColumn11.FormatInfo = Nothing
        Me.DataGridTextBoxColumn11.HeaderText = "Tipo de producto"
        Me.DataGridTextBoxColumn11.MappingName = "TipoProducto"
        Me.DataGridTextBoxColumn11.Width = 75
        '
        'DataGridTextBoxColumn12
        '
        Me.DataGridTextBoxColumn12.Format = ""
        Me.DataGridTextBoxColumn12.FormatInfo = Nothing
        Me.DataGridTextBoxColumn12.HeaderText = "Ruta"
        Me.DataGridTextBoxColumn12.MappingName = "Ruta"
        Me.DataGridTextBoxColumn12.Width = 150
        '
        'DataGridTextBoxColumn13
        '
        Me.DataGridTextBoxColumn13.Format = ""
        Me.DataGridTextBoxColumn13.FormatInfo = Nothing
        Me.DataGridTextBoxColumn13.HeaderText = "Camión"
        Me.DataGridTextBoxColumn13.MappingName = "AutoTanque"
        Me.DataGridTextBoxColumn13.Width = 65
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.HeaderText = "Unidad de medida"
        Me.DataGridTextBoxColumn9.MappingName = "UnidadMedida"
        Me.DataGridTextBoxColumn9.Width = 110
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn7.Format = "n"
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.HeaderText = "Capacidad al 100%"
        Me.DataGridTextBoxColumn7.MappingName = "Capacidad"
        Me.DataGridTextBoxColumn7.Width = 110
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn8.Format = "n"
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.HeaderText = "Capacidad      "
        Me.DataGridTextBoxColumn8.MappingName = "CapacidadOperativa"
        Me.DataGridTextBoxColumn8.Width = 110
        '
        'dgExistencia
        '
        Me.dgExistencia.AllowNavigation = False
        Me.dgExistencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgExistencia.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgExistencia.CaptionText = "Existencias"
        Me.dgExistencia.DataMember = ""
        Me.dgExistencia.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgExistencia.Location = New System.Drawing.Point(0, 77)
        Me.dgExistencia.Name = "dgExistencia"
        Me.dgExistencia.ReadOnly = True
        Me.dgExistencia.Size = New System.Drawing.Size(705, 158)
        Me.dgExistencia.TabIndex = 3
        Me.dgExistencia.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle3})
        Me.ToolTip1.SetToolTip(Me.dgExistencia, "Muestra las existencias del almacén seleccionado")
        '
        'DataGridTableStyle3
        '
        Me.DataGridTableStyle3.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle3.DataGrid = Me.dgExistencia
        Me.DataGridTableStyle3.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn14, Me.DataGridTextBoxColumn15, Me.DataGridTextBoxColumn16, Me.DataGridTextBoxColumn17})
        Me.DataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn14
        '
        Me.DataGridTextBoxColumn14.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn14.Format = "n0"
        Me.DataGridTextBoxColumn14.FormatInfo = Nothing
        Me.DataGridTextBoxColumn14.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn14.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn14.Width = 50
        '
        'DataGridTextBoxColumn15
        '
        Me.DataGridTextBoxColumn15.Format = ""
        Me.DataGridTextBoxColumn15.FormatInfo = Nothing
        Me.DataGridTextBoxColumn15.HeaderText = "Producto"
        Me.DataGridTextBoxColumn15.MappingName = "Producto"
        Me.DataGridTextBoxColumn15.Width = 160
        '
        'DataGridTextBoxColumn16
        '
        Me.DataGridTextBoxColumn16.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn16.Format = "n1"
        Me.DataGridTextBoxColumn16.FormatInfo = Nothing
        Me.DataGridTextBoxColumn16.HeaderText = "Total kilos"
        Me.DataGridTextBoxColumn16.MappingName = "Kilos"
        Me.DataGridTextBoxColumn16.Width = 75
        '
        'DataGridTextBoxColumn17
        '
        Me.DataGridTextBoxColumn17.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn17.Format = "n2"
        Me.DataGridTextBoxColumn17.FormatInfo = Nothing
        Me.DataGridTextBoxColumn17.HeaderText = "Total litros"
        Me.DataGridTextBoxColumn17.MappingName = "Litros"
        Me.DataGridTextBoxColumn17.Width = 75
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(837, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(88, 27)
        Me.btnBuscar.TabIndex = 1
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Consulta los almacenes de la célula seleccionada")
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(630, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Célula:"
        '
        'dgStock
        '
        Me.dgStock.AllowNavigation = False
        Me.dgStock.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgStock.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgStock.CaptionText = "Stock máximo"
        Me.dgStock.DataMember = ""
        Me.dgStock.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgStock.Location = New System.Drawing.Point(705, 77)
        Me.dgStock.Name = "dgStock"
        Me.dgStock.ReadOnly = True
        Me.dgStock.Size = New System.Drawing.Size(235, 158)
        Me.dgStock.TabIndex = 40
        Me.dgStock.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle2})
        Me.ToolTip1.SetToolTip(Me.dgStock, "Muestra el sotck máximo de carga del almacén seleccionado")
        '
        'DataGridTableStyle2
        '
        Me.DataGridTableStyle2.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle2.DataGrid = Me.dgStock
        Me.DataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6})
        Me.DataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "n0"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Cantidad"
        Me.DataGridTextBoxColumn3.MappingName = "Cantidad"
        Me.DataGridTextBoxColumn3.Width = 50
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Producto"
        Me.DataGridTextBoxColumn4.MappingName = "Producto"
        Me.DataGridTextBoxColumn4.Width = 160
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn5.Format = "n1"
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Total kilos"
        Me.DataGridTextBoxColumn5.MappingName = "Kilos"
        Me.DataGridTextBoxColumn5.Width = 75
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn6.Format = "n2"
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Total litros     "
        Me.DataGridTextBoxColumn6.MappingName = "Litros"
        Me.DataGridTextBoxColumn6.Width = 75
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(527, 9)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(9, 10)
        Me.btnCerrar2.TabIndex = 38
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(328, 96)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Button1"
        Me.Button1.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(448, 104)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 46
        Me.Button2.Text = "Button2"
        Me.Button2.Visible = False
        '
        'cboCelulaPtl
        '
        Me.cboCelulaPtl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboCelulaPtl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaPtl.ForeColor = System.Drawing.Color.MediumBlue
        Me.cboCelulaPtl.Location = New System.Drawing.Point(686, 10)
        Me.cboCelulaPtl.Name = "cboCelulaPtl"
        Me.cboCelulaPtl.Size = New System.Drawing.Size(142, 21)
        Me.cboCelulaPtl.TabIndex = 0
        '
        'pnTAlmacenExistencias
        '
        Me.pnTAlmacenExistencias.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnTAlmacenExistencias.AutoScroll = True
        Me.pnTAlmacenExistencias.Location = New System.Drawing.Point(0, 239)
        Me.pnTAlmacenExistencias.Name = "pnTAlmacenExistencias"
        Me.pnTAlmacenExistencias.Size = New System.Drawing.Size(931, 122)
        Me.pnTAlmacenExistencias.TabIndex = 42
        Me.pnTAlmacenExistencias.txtCantidad1 = Nothing
        '
        'frmPrincipal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(930, 386)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cboCelulaPtl)
        Me.Controls.Add(Me.pnTAlmacenExistencias)
        Me.Controls.Add(Me.dgStock)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dgExistencia)
        Me.Controls.Add(Me.dgAlmacen)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuPrincipal
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Control de movimientos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpUsuarioNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpDepartamento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpBaseDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAlmacen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgExistencia, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Metodo que llama a la funcion para realizar el corte de inventario "CODIGO PACO"
    Public Sub RealizarCorte()
        Dim Mensajes As New PortatilClasses.Mensaje(114)
        If MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim oCorte As New PortatilClasses.Consulta.cCorteInventario()
            oCorte.RealizarCorte()
        End If
    End Sub

    'Metodo que llama a la funcion para realizar un traslado "CODIGO PACO"
    Private Sub MostrarTrasladoVenta()
        Cursor = Cursors.WaitCursor
        Dim oTransladoCpra As New frmMovimientoTrasladoVenta()
        oTransladoCpra.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    '#002   INICIA
    'Metodo que inicializa y muestra la forma para capturar el programa de compras a PEMEX"
    Private Sub ProgramaCompras()
        Cursor = Cursors.WaitCursor
        Dim oProgramaCompra As New frmProgramaCompraVenta()
        oProgramaCompra.InicializaFormaCompra("COMPRA")
        oProgramaCompra.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    'Metodo que inicializa y muestra la forma para capturar el programa de ventas"
    Private Sub ProgramaVentas()
        Cursor = Cursors.WaitCursor
        Dim oProgramaVenta As New frmProgramaCompraVenta()
        oProgramaVenta.BackColor = Color.FromName("Gainsboro")
        oProgramaVenta.InicializaFormaCompra("VENTA")
        oProgramaVenta.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    '#002   TERMINA


    'Metodo que crea y llama a la forma del Catalogo de Almacen de Gas
    Private Sub CatalogoAlmacengas()
        Dim frmCatAlmacenGas As New MedicionFisica.frmCatAlmacenGas(GLOBAL_Usuario)
        frmCatAlmacenGas.Show()
    End Sub

    ' Carga la pantalla de registrar un embarque
    Private Sub EmbarqueTraspaso()
        Dim oEmbarqueTraspaso As New frmEmbarqueTraspaso()
        oEmbarqueTraspaso.Text = "Traspaso de embarque - [Agregar]"
        oEmbarqueTraspaso.Operacion = "Agregar"
        oEmbarqueTraspaso.ShowDialog()
    End Sub

    Private Sub InventarioFisico()
        Dim frmCatMedicionFisica As New MedicionFisica.frmCatMedicionFisica(GLOBAL_Usuario, GLOBAL_Password, GLOBAL_IDEmpleado, GLOBAL_UsuarioNombre, GLOBAL_CelulaDescripcion, GLOBAL_BaseDatos, GLOBAL_Servidor, GLOBAL_RutaReportes, GLOBAL_Celula, GLOBAL_Empresa, GLOBAL_Conexion)
        If GLOBAL_FechaHoraCierre = "1" Then
            frmCatMedicionFisica.FechaHoraCierre = True
        End If
        frmCatMedicionFisica.ShowDialog()
    End Sub

    'Metodo que visualiza las pantallas para poder realizar una liquidacion portatil
    Private Sub LiquidacionPortatil()
        Dim frmLiquidacionPortatil As New LiquidacionPortatil.frmLiquidacionConsulta(GLOBAL_Usuario, GLOBAL_IDEmpleado, CType(GLOBAL_CajaUsuario, Byte), GLOBAL_FactorDensidad, GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Password, GLOBAL_Empresa, GLOBAL_Sucursal)
        If frmLiquidacionPortatil.Validated Then
            frmLiquidacionPortatil.ShowDialog()
        End If
    End Sub

    'Metodo que crea y llama a la forma del Catálogo Tanque
    Private Sub CatalogoTanque()
        Dim frmCatTanqueFisico As New MedicionFisica.frmCatTanqueFisico(GLOBAL_Usuario)
        frmCatTanqueFisico.Show()
    End Sub

    'Metodo que crea y llama a la forma del Catalogo de Corporativo
    Private Sub CatalogoCorporativo()
        Dim frmCatCorporativo As New MedicionFisica.frmCatCorporativo()
        frmCatCorporativo.Show()
    End Sub


    ' solo carga las fechas para que el usuario pueda seleccionar el rango de fecha y enseguida consulte el
    ' kardex
    Private Sub MostrarReporte(ByVal AlmacenGas As String)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor,
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password,
                            "ReporteKardex.rpt")
        oReporte.AddParametros(AlmacenGas, False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.AddParametros("0", False)
        oReporte.AddParametros(AlmacenGas, False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.ShowDialog()
    End Sub

    Private Sub MostrarReporteTeorico()
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporteFechas(GLOBAL_RutaReportes, GLOBAL_Servidor,
                            GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password,
                            "ReporteContable.rpt")
        oReporte.AddParametros("0", False)
        oReporte.AddParametros("FechaInicial", True)
        oReporte.AddParametros("FechaFinal", True)
        oReporte.ShowDialog()
    End Sub


    ' Muestra el tipo de carga que se realizará, desplieaga la forma de carga dependiendo de la configuración 
    ' si es comisionista o no la empresa
    Private Sub MostrarCarga()
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim Stock As String
        GLOBAL_EmpresaComisionista = CType(oConfig.Parametros("EmpresaComisionista"), String).Trim
        Stock = CType(oConfig.Parametros("StockCarga"), String).Trim

        If GLOBAL_EmpresaComisionista = "1" Then
            Cursor = Cursors.WaitCursor
            Dim oCargaCliente As New frmCargaCliente()
            oCargaCliente.ShowDialog()
            Cursor = Cursors.Default
        Else
            Cursor = Cursors.WaitCursor
            Dim oCarga As frmMovimientoAlmacen
            oCarga = New frmMovimientoAlmacen()
            oCarga.Stock = Stock
            oCarga.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Despliega las entradas del almacén seleccionado
    Private Sub MostrarEntradas()
        If dgAlmacen.VisibleRowCount > 0 Then
            Dim oMovimiento As New frmMovimientos()
            oMovimiento.Text = "Entradas del almacén " & CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 1), String)
            oMovimiento.TipoMovimiento = "ENTRADA"
            oMovimiento.Almacen = CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer)
            oMovimiento.ShowDialog()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, GLOBAL_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Despliega las salidas del almacén seleccionado
    Private Sub MostrarSalidas()
        If dgAlmacen.VisibleRowCount > 0 Then
            Dim oMovimiento As New frmMovimientos()
            oMovimiento.Text = "Salidas del almacén " & CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 1), String)
            oMovimiento.TipoMovimiento = "SALIDA"
            oMovimiento.Almacen = CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer)
            oMovimiento.ShowDialog()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(11)
            MessageBox.Show(Mensajes.Mensaje, GLOBAL_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Muestra la forma de traspasos de gas
    Private Sub MostrarTraslado()
        Cursor = Cursors.WaitCursor
        Dim oTranslado As New frmMovimientoTraslado()
        oTranslado.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub MostrarTrasladoCompra()
        Cursor = Cursors.WaitCursor
        Dim oTransladoCpra As New frmMovimientoTrasladoCompra()
        oTransladoCpra.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    ' Muestra la forma de consulta de embarques
    Private Sub MostrarEmbarque()
        Dim oConsultaEmbarque As New frmConsultaEmbarque()
        oConsultaEmbarque.ShowDialog()
    End Sub

    Private Sub MostrarDucto()
        Dim oConsultaDucto As New frmConsultaDucto()
        oConsultaDucto.ShowDialog()
    End Sub

    Private Sub MostrarAutoConsumo()
        Dim oAutoConsumo As New frmMovimientoAutoConsumo()
        oAutoConsumo.ShowDialog()
    End Sub

    Private Sub MostrarReposicionFugas()
        '20051203CAGP$000 /I
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim EmpresaComisionista As String
        Dim Stock As String
        EmpresaComisionista = CType(oConfig.Parametros("EmpresaComisionista"), String).Trim
        Stock = CType(oConfig.Parametros("StockCarga"), String).Trim

        If EmpresaComisionista = "1" Then

        Else
            Cursor = Cursors.WaitCursor
            Dim oReposicion As frmReposicionFugasPortatil
            oReposicion = New frmReposicionFugasPortatil()
            oReposicion.ShowDialog()
            Cursor = Cursors.Default
        End If
        '20051203CAGP$000 /F
    End Sub

    ' Muestra el reporteador para consultar el Kardex
    Private Sub MostrarKardex()
        If GLOBAL_Reportes Then
            If dgAlmacen.VisibleRowCount > 0 Then
                MostrarReporte(CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), String))
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(11)
                MessageBox.Show(Mensajes.Mensaje, GLOBAL_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(24)
            MessageBox.Show(Mensajes.Mensaje, GLOBAL_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' Refrescar la información de los almaceens
    Private Sub Refrescar()
        If cboCelulaPtl.Text <> "" Then
            CargarAlmacenes(CType(cboCelulaPtl.Identificador, Short))
            pnTAlmacenExistencias.CargarResumen(0, CType(cboCelulaPtl.Identificador, Short))
        Else
            CargarAlmacenes(GLOBAL_Celula)
            pnTAlmacenExistencias.CargarResumen(0, GLOBAL_Celula)
        End If

        'If cboCelula.Text <> "" Then
        '    CargarAlmacenes(cboCelula.Celula)
        '    pnTAlmacenExistencias.CargarResumen(0, cboCelula.Celula)
        'Else
        '    CargarAlmacenes(GLOBAL_Celula)
        '    pnTAlmacenExistencias.CargarResumen(0, GLOBAL_Celula)
        'End If
    End Sub

    ' Carga los datos de las existencias de los almacenes registrados al DataGrid
    Private Sub CargarExistencias(ByVal AlmacenGas As Integer)
        dgExistencia.DataSource = Nothing
        Dim oExistencia As New PortatilClasses.Consulta.cExistencia(3, AlmacenGas, 0, 0)
        oExistencia.CargaDatos(3)
        dgExistencia.DataSource = oExistencia.dtTable
        oExistencia = Nothing
    End Sub

    ' Carga los datos del stock de carga maximo al DataGrid de Stock
    Private Sub CargarStock(ByVal AlmacenGas As Integer)
        dgStock.DataSource = Nothing
        Dim oStock As New PortatilClasses.Catalogo.cAlmacenGasStock()
        oStock.Consultar(2, AlmacenGas)
        dgStock.DataSource = oStock.dtTable
        oStock = Nothing
    End Sub

    ' Cargo los datos de los almacenes registrados al DataGrid
    Private Sub CargarAlmacenes(ByVal Celula As Short)
        dgAlmacen.DataSource = Nothing
        dgExistencia.DataSource = Nothing
        dgStock.DataSource = Nothing
        Dim oAlmacenGas As New PortatilClasses.CatalogosPortatil.cAlmacenGas(6, 0, "0", Now, "0", 0, 0, 0, Celula, 0, 0, "0", 0, 0)
        oAlmacenGas.ConsultarAlmacenGas()
        dgAlmacen.DataSource = oAlmacenGas.dtTable
        oAlmacenGas = Nothing
        If dgAlmacen.VisibleRowCount > 0 Then
            CargarExistencias(CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer))
            CargarStock(CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer))
        End If
    End Sub

    Private Sub Mitad()
        Dim Mitad As Integer
        Mitad = Me.Width \ 2
        dgExistencia.Width = Mitad
        dgStock.Location = New System.Drawing.Point(Mitad, dgStock.Location.Y)
        dgStock.Width = Mitad
    End Sub

    ' Evento del menu Salir
    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    ' Evento ques e ejecuta al momento de cerrar la forma
    Private Sub frmPrincipal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("¿Desea salir de la aplicación?", GLOBAL_Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    ' Evento de inicialización de la forma, inciializa el Status Bar con la información establecida
    Private Sub frmPrincipal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cboCelula.CargaDatos()

        If GLOBAL_VerTodosAlmacenes Then
            cboCelulaPtl.CargaDatosBase("spPTLCargaComboCelula", 1, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        Else
            cboCelulaPtl.CargaDatosBase("spPTLCargaComboCelula", 2, GLOBAL_Usuario, GLOBAL_Empresa, 0, 0)
        End If
        'cboCelulaPtl.PosicionaCombo(GLOBAL_Celula)

        'StatusBar
        sbpUsuario.Text = GLOBAL_Usuario
        sbpUsuarioNombre.Text = GLOBAL_UsuarioNombre
        sbpDepartamento.Text = GLOBAL_CelulaDescripcion
        sbpBaseDatos.Text = GLOBAL_BaseDatos
        sbpServidor.Text = GLOBAL_Servidor
        sbpVersion.Text = "Control de movimientos Versión: " & Application.ProductVersion
        ' Habilita los privilegio del usuario
        ToolBar1.Buttons.Item(2).Enabled = GLOBAl_Carga
        mnuCarga.Enabled = GLOBAl_Carga
        ToolBar1.Buttons.Item(3).Enabled = GLOBAL_Traslado
        mnuTraslado.Enabled = GLOBAL_Traslado
        ToolBar1.Buttons.Item(5).Enabled = GLOBAL_Embarque
        mnuEmbarque.Enabled = GLOBAL_Embarque
        mnuParametros.Enabled = GLOBAL_Parametros
        ' Hbailita el acceso a reportes
        mnuKardex.Enabled = GLOBAL_Reportes
        ToolBar1.Buttons.Item(7).Enabled = GLOBAL_Reportes
        mnuReportes.Enabled = GLOBAL_Reportes
        'mnuReporteFisico.Visible = GLOBAL_ReporteFisico
        '17-10-2005 Deshabilitado lo puso en la parte del inventario fisico
        mnuReporteFisico.Visible = False
        mnuReporteContable.Visible = GLOBAL_ReporteContable

        mnuInventarioInicial.Enabled = GLOBAL_InventarioInicial

        mnuEResguardo.Enabled = GLOBAl_ReposicionResguardo
        mnuSReposicion.Enabled = GLOBAl_ReposicionResguardo
        mnuCatalogos.Enabled = GLOBAL_VerCatalogos

        Dim oConfigFactor As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim GLOBAL_Resguardo As Boolean
        GLOBAL_Resguardo = CType(CType(oConfigFactor.Parametros("ResguardoPipaCuata"), String).Trim, Boolean)
        mnuEResguardo.Enabled = Not GLOBAL_Resguardo
        mnuSReposicion.Enabled = Not GLOBAL_Resguardo

        mnuAutoCarburacion.Enabled = GLOBAL_AutoCarburacion
        mnuConsumo.Enabled = GLOBAL_Consumo

        mnuTrasladoCpra.Enabled = GLOBAL_TrasladosCpraVta
        mnuBttTrasladoCpra.Enabled = GLOBAL_TrasladosCpraVta
        mnuTrasladoVta.Enabled = GLOBAL_TrasladosCpraVta
        ' Modulo integrado
        mnuBascula.Visible = CType(GLOBAL_ModuloIntegrado, Boolean)
        mnuVtaPortatil.Visible = True 'CType(GLOBAL_ModuloIntegrado, Boolean)
        mnuVtaCarburacion.Visible = CType(GLOBAL_ModuloIntegrado, Boolean)


        If GLOBAL_Ducto = "1" Then
            mnuBttDucto.Enabled = GLOBAL_Ducto18
            mnuDucto.Enabled = GLOBAL_Ducto18
        Else
            mnuBttDucto.Enabled = False
            mnuDucto.Enabled = False
        End If

        'Privilegios Inventario Fisico
        If GLOBAL_MedicionFisica Then
            mnuSeparadorMovimientos.Visible = GLOBAL_InventarioFisico       '#002
            mnuInventarioFisico.Visible = GLOBAL_InventarioFisico
        Else
            mnuSeparadorMovimientos.Visible = GLOBAL_InventarioFisico       '#002
            mnuInventarioFisico.Visible = GLOBAL_MedicionFisica
        End If

        '#002   INICIA
        'Privilegios Programa Compras
        If GLOBAL_ProgramaCompras Then
            mnuSeparadorCompras.Visible = GLOBAL_ProgramaCompras
            mnuProgramaCompra.Visible = GLOBAL_ProgramaCompras
        Else
            mnuSeparadorCompras.Visible = GLOBAL_ProgramaCompras
            mnuProgramaCompra.Visible = GLOBAL_ProgramaCompras
        End If

        If GLOBAL_ProgramaVentas Then
            mnuSeparadorVentas.Visible = GLOBAL_ProgramaCompras
            mnuProgramaVenta.Visible = GLOBAL_ProgramaCompras
        Else
            mnuSeparadorVentas.Visible = GLOBAL_ProgramaCompras
            mnuProgramaVenta.Visible = GLOBAL_ProgramaCompras
        End If
        '#002   TERMINA
        mnuKilometraje.Visible = GLOBAL_ConsultarKm ' 20080807CAGP$001
        MenuItem7.Visible = GLOBAL_ConsultarKm ' 20080807CAGP$001
        mnuPreliquidacion.Visible = GLOBAL_PreliquidacionPort '20111122CAGP$001

        If GLOBAL_EmpresaComisionista = "1" Then
            mnuComisionista.Visible = True
        End If
        Try
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim inabilitar As Integer = CType(oConfig.Parametros("LiquidacionPortail"), Integer)
            If inabilitar <> 1 Then
                mnuReposicionFugas.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show("No contiene valor el parametro LiquidacionPortail.  " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        mnuConfiguracion.Visible = GLOBAL_ComConfiguracion
        mnuComisiones.Visible = GLOBAL_ComConsultarComisiones
        mnuImportar.Visible = GLOBAL_ImportarVtas
        mnuSalidaTrasiego.Visible = GLOBAL_Trasiego
        mnuInventarioFisicoActaCierre.Visible = GLOBAL_InventarioFisicoActaCierre

        Refresh()

        CargarAlmacenes(GLOBAL_Celula)
        pnTAlmacenExistencias.CargarResumen(0, GLOBAL_Celula)
        'ActiveControl = cboCelula
        ActiveControl = cboCelulaPtl

    End Sub

    ' Muestra la versión del programa
    Private Sub mnuAcercaDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAcercaDe.Click
        Dim oAcercaDe As New SigaMetClasses.AcercaDe(Application.ProductName, Application.ProductVersion, "Módulo de " & GLOBAL_Titulo)
        oAcercaDe.ShowDialog()
    End Sub

    ' Muestra la forma de carga portatil
    Private Sub mnuCarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCarga.Click
        MostrarCarga()
    End Sub

    ' Muestra los reportes que pertenecen al modulo 16, portatil
    Private Sub mnuReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportes.Click
        Dim oReporte As New ReporteDinamico.frmListaReporte(GLOBAL_Modulo, GLOBAL_RutaReportes, GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Conexion, GLOBAL_Empresa, GLOBAL_Sucursal, GLOBAL_SeguridadReportes)
        oReporte.Show()
    End Sub

    ' Muestra la forma de traspasos de gas
    Private Sub mnuTraspaso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTraslado.Click
        MostrarTraslado()
    End Sub

    ' Muestra la forma de embarques
    Private Sub mnuEmbarque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEmbarque.Click
        MostrarEmbarque()
    End Sub

    ' Busca los almacenes de la celula seleccionada
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        'CargarAlmacenes(cboCelula.Celula)
        'pnTAlmacenExistencias.CargarResumen(0, cboCelula.Celula)

        CargarAlmacenes(CType(cboCelulaPtl.Identificador, Short))
        pnTAlmacenExistencias.CargarResumen(0, CType(cboCelulaPtl.Identificador, Short))
    End Sub

    ' Muestra las existencias de cada almacén al seleccionar cada almacén
    Private Sub dgAlmacen_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgAlmacen.CurrentCellChanged
        If dgAlmacen.VisibleRowCount > 0 Then
            CargarExistencias(CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer))
            CargarStock(CType(dgAlmacen.Item(dgAlmacen.CurrentRowIndex, 0), Integer))
        End If
    End Sub

    ' Evento que se activa al dar clic a la barra de opciones
    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case ToolBar1.Buttons.IndexOf(e.Button)
            Case 0
                ' Despliega las entradas del almacén seleccionado
                MostrarEntradas()
            Case 1
                ' Despliega las salidas del almacén seleccionado
                MostrarSalidas()
            Case 2
                ' Carga la forma de carga portatil
                MostrarCarga()
            Case 3
                ' Muestra la forma de traspasos de gas
                MostrarTraslado()
            Case 5
                ' Muestra la forma de consulta de embarques
                MostrarEmbarque()
            Case 7
                ' Muestra el reporteador para consultar el Kardex
                MostrarKardex()
            Case 9
                ' Refrescar la información mostrada de los almacenes
                Refrescar()
            Case 11
                Close()
        End Select
    End Sub

    ' Muestra la forma para cambiar el password del usuario logeado
    Private Sub mnuCambioClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioClave.Click
        Dim frmCambioClave As New SigaMetClasses.CambioClave(GLOBAL_Usuario)
        frmCambioClave.ShowDialog()
    End Sub

    ' Muestra lso parametros del modulo, permite agregar uno nuevo o modificar los existentes
    Private Sub mnuParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParametros.Click
        Cursor = Cursors.WaitCursor
        Dim oParametros As New SigaMetClasses.ConsultaParametros(GLOBAL_Modulo)
        oParametros.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    ' Muestra el reporte del Kardex de cada almacén
    Private Sub mnuKardex_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuKardex.Click
        MostrarKardex()
    End Sub

    ' Cierra la forma
    Private Sub btnCerrar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Close()
    End Sub

    Private Sub frmPrincipal_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        Mitad()
    End Sub

    Private Sub mnuBttEmbarque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBttEmbarque.Click
        ' Muestra la forma de consulta de embarques
        MostrarEmbarque()
    End Sub

    Private Sub mnuTrasladoCpra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTrasladoCpra.Click
        MostrarTrasladoCompra()
    End Sub

    Private Sub mnuBttTrasladoCpra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBttTrasladoCpra.Click
        MostrarTrasladoCompra()
    End Sub

    Private Sub mnuEResguardo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEResguardo.Click
        If Not mnuEResguardo.Enabled Then
            Dim ofrmResguardoEntrada As New Resguardo.frmResguardo()
            ofrmResguardoEntrada.InicializaForma(133015, 2005, Now, GLOBAL_Usuario, GLOBAL_Password, GLOBAL_Empresa, GLOBAL_Sucursal)
            ofrmResguardoEntrada.ShowDialog()
        Else
            Dim oResguardoEntrada As New frmMovimientoResguardoEntrada()
            oResguardoEntrada.ShowDialog()
        End If
    End Sub

    Private Sub mnuSReposicion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSReposicion.Click
        Dim oResguardoSalida As New frmMovimientoResguardoSalida()
        oResguardoSalida.ShowDialog()
    End Sub

    Private Sub mnuAutoCarburacion_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAutoCarburacion.Click
        Dim oAutocarburacion As New frmMovimientoAutoCarburacion()
        oAutocarburacion.TipoMovimiento = 9
        oAutocarburacion.ShowDialog()
    End Sub

    Private Sub mnuInventarioInicial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInventarioInicial.Click
        Dim oInventarioInicial As New frmMovimientoInicial()
        oInventarioInicial.ShowDialog()
    End Sub

    Private Sub mnuDestinos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDestinos.Click
        Dim a As New Bascula.frmDestinos()
        a.ShowDialog()
    End Sub

    Private Sub mnuTransportadoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTransportadoras.Click
        Dim a As New Bascula.frmTransportadoras()
        a.ShowDialog()
    End Sub

    Private Sub mnuCiclo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCiclo.Click
        Dim a As New Bascula.frmAutotanques()
        a.ShowDialog()
    End Sub

    Private Sub mnuModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificar.Click
        Dim a As New Bascula.frmModificacionCiclos()
        a.ShowDialog()
    End Sub

    Private Sub mnuDucto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDucto.Click
        MostrarDucto()
    End Sub

    Private Sub mnuBttDucto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuBttDucto.Click
        MostrarDucto()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuInventarioFisico.Click
        InventarioFisico()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        CatalogoAlmacengas()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        CatalogoTanque()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        CatalogoCorporativo()
    End Sub

    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVtaPortatil.Click
        LiquidacionPortatil()
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        EmbarqueTraspaso()
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsumo.Click
        MostrarAutoConsumo()
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        RealizarCorte()
    End Sub

    Private Sub MenuItem8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTrasladoVta.Click
        MostrarTrasladoVenta()
    End Sub

    Private Sub MenuItem8_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReporteContable.Click
        MostrarReporteTeorico()
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVtaCarburacion.Click
        Dim oAutocarburacion As New frmMovimientoAutoCarburacion()
        oAutocarburacion.TipoMovimiento = 24
        oAutocarburacion.Text = "Venta de gas por carburación"
        oAutocarburacion.ShowDialog()
    End Sub

    Private Sub mnuReposicionFugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReposicionFugas.Click
        '20051203CAGP $000
        MostrarReposicionFugas()
    End Sub

    '#002   INICIA
    Private Sub mnuProgramaCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgramaCompra.Click
        ProgramaCompras()
    End Sub

    Private Sub mnuProgramaVenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuProgramaVenta.Click
        ProgramaVentas()
    End Sub
    '#002   TERMINA

    '20060302CAGP$001 /I
    Private Sub mnuDevolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDevolucion.Click
        Dim oDevolucion As New frmMovimientoDevolucionEntrada()
        oDevolucion.ShowDialog()
    End Sub
    '20060302CAGP$001 /F

    Private Sub mnuKilometraje_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuKilometraje.Click
        Dim oKilometraje As New frmKilometrajes()
        oKilometraje.ShowDialog()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oReportes As New ExportarAExcel.ReporteEmbarques(GLOBAL_Usuario, GLOBAL_Password, Now.AddMonths(-2), Now, GLOBAL_ConString)
        oReportes.GeneraArchivo()
    End Sub

    Private Sub mnuClienteComisionista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oCliente As New ClienteZonaEconomica.frmConsultaFactorCliente()
        oCliente.ShowDialog()
        oCliente = Nothing
    End Sub

    Private Sub MenuItem8_Click_3(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oPrestacion As New ClienteZonaEconomica.frmConfigurarPrestaciones()
        oPrestacion.ShowDialog()
    End Sub

    Private Sub MenuItem9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oDeduccion As New ClienteZonaEconomica.frmDeducciones()
        oDeduccion.ShowDialog()
    End Sub

    Private Sub MenuItem10_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oComision As New ClienteZonaEconomica.frmComision()
        oComision.ShowDialog()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '    Dim cambioZona As New ClienteZonaEconomica.frmClienteZonaEconomica(2, _
        'GLOBAL_Usuario, GLOBAL_Password, GLOBAL_Conexion)
        '    cambioZona.StartPosition = FormStartPosition.CenterScreen
        '    cambioZona.ShowDialog()
        Dim oCargar As New ClienteZonaEconomica.frmMovimientoAlmacenPedidos(CType("16-01-2012", DateTime), GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Usuario, GLOBAL_Password, GLOBAL_RutaReportes, GLOBAL_Conexion)
        oCargar.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim frmConsulta As New LiquidacionPortatil.frmPreLiquidacionConsultaCyC(GLOBAL_Usuario, GLOBAL_IDEmpleado, CType(GLOBAL_CajaUsuario, Byte), GLOBAL_FactorDensidad, GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Password, GLOBAL_Empresa, GLOBAL_Sucursal)
        If frmConsulta.Validated Then
            frmConsulta.ShowDialog()
        End If
    End Sub

    Private Sub mnuPreliquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuPreliquidacion.Click
        Dim frmConsulta As New LiquidacionPortatil.frmPreLiquidacionConsultaCyC(GLOBAL_Usuario, GLOBAL_IDEmpleado, CType(GLOBAL_CajaUsuario, Byte), GLOBAL_FactorDensidad, GLOBAL_Servidor, GLOBAL_BaseDatos, GLOBAL_Password, GLOBAL_Empresa, GLOBAL_Sucursal)
        If frmConsulta.Validated Then
            frmConsulta.ShowDialog()
        End If
    End Sub

    Private Sub mnuConfiguracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConfiguracion.Click
        Dim oCliente As New ClienteZonaEconomica.frmConsultaFactorCliente()
        oCliente.ShowDialog()
        oCliente = Nothing
    End Sub

    Private Sub MenuItem12_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oPrestacion As New ClienteZonaEconomica.frmConfigurarPrestaciones()
        oPrestacion.ShowDialog()
    End Sub

    Private Sub mnuDeducciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oDeduccion As New ClienteZonaEconomica.frmDeducciones()
        oDeduccion.ShowDialog()
    End Sub

    Private Sub mnuComisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuComisiones.Click
        Dim oComision As New ClienteZonaEconomica.frmComision()
        oComision.ShowDialog()
    End Sub

    Private Sub mnuImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuImportar.Click
        Dim oImportar As New frmImportarVentas()
        oImportar.ShowDialog()
    End Sub

    Private Sub mnuSalidaTrasiego_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalidaTrasiego.Click
        Dim oTrasiego As New frmTrasiegoSalida()
        oTrasiego.ShowDialog()
    End Sub

    Private Sub mnuInventarioFisicoActaCierre_Click(sender As System.Object, e As System.EventArgs) Handles mnuInventarioFisicoActaCierre.Click
        InventarioFisicoPorActaCierre()
    End Sub

    Private Sub InventarioFisicoPorActaCierre()
        Dim stlPermisosActaCierre As New SortedList()
        stlPermisosActaCierre.Add("CancelacionTomaInventarioActaCierre", GLOBAL_CancelacionTomaIActaCierre)
        stlPermisosActaCierre.Add("CancelacionControlRecipientesActaCierre", GLOBAL_CancelacionControlRecipientesActaCierre)
        stlPermisosActaCierre.Add("AccesoReportesAtaCierre", GLOBAL_AccesoReportesAtaCierre)
        stlPermisosActaCierre.Add("AltaActaCierre", GLOBAL_AltaActaCierre)
        stlPermisosActaCierre.Add("CierreActaCierre", GLOBAL_CierreActaCierre)
        stlPermisosActaCierre.Add("CancelacionActaCierre", GLOBAL_CancelacionActaCierre)
        stlPermisosActaCierre.Add("ModificarControlRecipientesActaCierre", GLOBAL_ModificarControlRecipientesActaCierre)
        stlPermisosActaCierre.Add("AbrirActaCierre", GLOBAL_AbrirActaCierre)

        Dim frmCatMedicionFisica As New ActaCierreClasses.frmConsultaAudiotoria(GLOBAL_RutaReportes, stlPermisosActaCierre)
        frmCatMedicionFisica.ShowDialog()

    End Sub

    Private Sub MenuItem2_Click_1(sender As System.Object, e As System.EventArgs)
        Dim oReporte As New ReporteDinamicoOaxaca.frmReporte("\\192.168.1.21\SigametReportesW7\Inventario", "ReporteLiquidacionComision.rpt", "192.168.1.27",
               "Sigamet", "SIGAREP", "SIGAREP", False)
        oReporte.ListaParametros.Add(8)
        oReporte.ListaParametros.Add(677522)

        oReporte.ShowDialog()
    End Sub
End Class
