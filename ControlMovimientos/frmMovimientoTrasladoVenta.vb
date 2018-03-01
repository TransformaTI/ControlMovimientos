'' Pantalla para realizar traslados unicamente cuando es entre empresas diferentes, de lo
' contrario no se podra realizar el movimiento.
' Si el traslado es a detalle de empresa y almacén se registrarán tanto la SALIDA y la
' la ENTRADA.
' Si no es a detalle de empresa y almacén se resgistrará solo la ENTRADA

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 29/12/2005
'Motivo: Se corrijio los parametros de INICIALIZAFORMA
'Identificador de cambios: 20051229CAGP$006

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 23/01/2006
'Motivo: Se agrego el ticket por traslados fisico
'Identificador de cmabios: 20060123CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 25/01/2006
'Motivo: Se modifico y valido varias lineas de la forma

'Modifico: Claudia Aurora García Patiño
'Fecha: 01/03/2006
'Motivo: Se modifico la linea de existencias
'Identificador de cambios: 20060301CAGP$001

'Modifico: Claudia Aurora García Patiño
'Fecha: 03/03/2006
'Motivo: SE configuro para que no incrementara el totalziador y se volviera aincrementar en el area de bascula
'Identificador de cambios: 20060303CAGP$004

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/03/2006
'Motivo: Se modifico y valido varias lineas de la forma debido a que se le agrego celula origen

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$013

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 11/09/2006
'Motivo: Se aumento el control de cboCelulaOrigen

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 11/01/2007
'Motivo: Se modifico el calculo del factor de densidad
'Identificador de cambios: 20070111CAGP$003

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/07/2007
'Motivo: Se aumento un parametro para la validación de litros porcentaje y totalizador
'Identificador de cambios: 20070706CAGP$006

Imports PortatilClasses.Consulta
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoTrasladoVenta
    Inherits System.Windows.Forms.Form

    Private Producto As Integer
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private EntradaSalida As Boolean

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
    Friend WithEvents cboAlmacenOrig As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents cboAlmacenDest As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblKilos As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboCorporativoOrig As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboCorporativoDest As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents dtpFTraslado As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pdImprimir As System.Windows.Forms.PrintDialog
    Friend WithEvents txtTotFinal As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTotInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboCelulaDestino As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboCelulaOrigen As PortatilClasses.Combo.ComboBase
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoTrasladoVenta))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.cboCelulaDestino = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTotInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFTraslado = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.cboCorporativoOrig = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboCorporativoDest = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAlmacenOrig = New PortatilClasses.Combo.ComboAlmacen()
        Me.cboAlmacenDest = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblKilos = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.pdImprimir = New System.Windows.Forms.PrintDialog()
        Me.cboCelulaOrigen = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboCelulaOrigen, Me.Label8, Me.cboCelulaDestino, Me.Label4, Me.txtTotFinal, Me.txtTotInicial, Me.Label5, Me.Label7, Me.dtpFTraslado, Me.Label1, Me.ProductoPanel, Me.cboCorporativoOrig, Me.Label3, Me.cboCorporativoDest, Me.Label2, Me.cboAlmacenOrig, Me.cboAlmacenDest, Me.Label12, Me.Label13, Me.lblProducto, Me.lblKilos, Me.Label6, Me.dtpFMovimiento})
        Me.grpDatos.Location = New System.Drawing.Point(16, 8)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 496)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        '
        'cboCelulaDestino
        '
        Me.cboCelulaDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaDestino.Location = New System.Drawing.Point(131, 135)
        Me.cboCelulaDestino.Name = "cboCelulaDestino"
        Me.cboCelulaDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCelulaDestino.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 13)
        Me.Label4.TabIndex = 52
        Me.Label4.Text = "Célula destino:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotFinal
        '
        Me.txtTotFinal.AutoSize = False
        Me.txtTotFinal.Location = New System.Drawing.Point(131, 273)
        Me.txtTotFinal.MaxLength = 12
        Me.txtTotFinal.Name = "txtTotFinal"
        Me.txtTotFinal.Size = New System.Drawing.Size(216, 21)
        Me.txtTotFinal.TabIndex = 9
        Me.txtTotFinal.Text = ""
        '
        'txtTotInicial
        '
        Me.txtTotInicial.AutoSize = False
        Me.txtTotInicial.Location = New System.Drawing.Point(131, 245)
        Me.txtTotInicial.MaxLength = 12
        Me.txtTotInicial.Name = "txtTotInicial"
        Me.txtTotInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtTotInicial.TabIndex = 8
        Me.txtTotInicial.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 249)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "Totalizador inicial:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(16, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 50
        Me.Label7.Text = "Totalizador final:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFTraslado
        '
        Me.dtpFTraslado.CustomFormat = ""
        Me.dtpFTraslado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFTraslado.Location = New System.Drawing.Point(131, 218)
        Me.dtpFTraslado.Name = "dtpFTraslado"
        Me.dtpFTraslado.Size = New System.Drawing.Size(216, 21)
        Me.dtpFTraslado.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(16, 222)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Fecha traslado:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Location = New System.Drawing.Point(8, 304)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(463, 152)
        Me.ProductoPanel.TabIndex = 10
        Me.ProductoPanel.txtCantidad1 = Nothing
        '
        'cboCorporativoOrig
        '
        Me.cboCorporativoOrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoOrig.Location = New System.Drawing.Point(131, 24)
        Me.cboCorporativoOrig.Name = "cboCorporativoOrig"
        Me.cboCorporativoOrig.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoOrig.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(16, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(94, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Empresa origen:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCorporativoDest
        '
        Me.cboCorporativoDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoDest.Location = New System.Drawing.Point(131, 107)
        Me.cboCorporativoDest.Name = "cboCorporativoDest"
        Me.cboCorporativoDest.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoDest.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(16, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Empresa destino:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacenOrig
        '
        Me.cboAlmacenOrig.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenOrig.Location = New System.Drawing.Point(131, 79)
        Me.cboAlmacenOrig.Name = "cboAlmacenOrig"
        Me.cboAlmacenOrig.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenOrig.TabIndex = 2
        '
        'cboAlmacenDest
        '
        Me.cboAlmacenDest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenDest.Location = New System.Drawing.Point(131, 162)
        Me.cboAlmacenDest.Name = "cboAlmacenDest"
        Me.cboAlmacenDest.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacenDest.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(16, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 13)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Almacén origen:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(16, 166)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(99, 13)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "Almacén destino:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Location = New System.Drawing.Point(320, 466)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(30, 13)
        Me.lblProducto.TabIndex = 17
        Me.lblProducto.Text = "Kilos:"
        Me.lblProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblKilos
        '
        Me.lblKilos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKilos.Location = New System.Drawing.Point(359, 462)
        Me.lblKilos.Name = "lblKilos"
        Me.lblKilos.Size = New System.Drawing.Size(120, 21)
        Me.lblKilos.TabIndex = 15
        Me.lblKilos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(16, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(131, 190)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 6
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(520, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 1
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(520, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 0
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboCelulaOrigen
        '
        Me.cboCelulaOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelulaOrigen.Location = New System.Drawing.Point(131, 51)
        Me.cboCelulaOrigen.Name = "cboCelulaOrigen"
        Me.cboCelulaOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboCelulaOrigen.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(16, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "Célula origen:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmMovimientoTrasladoVenta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(600, 512)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoTrasladoVenta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Venta por traslado de gas a empresa filial"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim frmCapturaMedicionEstacionario As New MedicionFisica.frmMedicionInicialFinalEst()
    Dim frmCapturaMedicionTanque As New MedicionFisica.frmMedicionTanqueAlmacen()

    '20070706CAGP$006 /I
    'Valida que los litros según porcentaje concuerden con los litros totalizador
    Function PermitirPorTotHd() As Boolean
        If frmCapturaMedicionEstacionario.PermitirTotalizadorPorcentaje(CType(lblKilos.Text, Decimal), GLOBAL_PorcentajePermitido) = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(96)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        Else
            Return True
        End If
    End Function

    'Valida que los litros según porcentaje concuerden con los litros totalizador
    Function PermitirPorTotTanque() As Boolean
        If frmCapturaMedicionTanque.PermitirTotalizadorPorcentaje(CType(lblKilos.Text, Decimal), GLOBAL_PorcentajePermitido) = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(96)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        Else
            Return True
        End If
    End Function
    '20070706CAGP$006 /F

    Private Sub MedicionFisicaPortatil(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    Private Sub DestruyeMedicionFisicaEstacionario()
        frmCapturaMedicionEstacionario = Nothing
        frmCapturaMedicionEstacionario = New MedicionFisica.frmMedicionInicialFinalEst()
        frmCapturaMedicionTanque = Nothing
        frmCapturaMedicionTanque = New MedicionFisica.frmMedicionTanqueAlmacen()
    End Sub

    Function MedicionFisica() As Boolean
        If cboAlmacenDest.Identificador > 0 Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDest.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            oAlmacenDestino.CargarAlmacenGas()

            If oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 4 Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrig.Identificador, 0)
                oTanque.VerificarCapacidad()
                frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                '20060301CAGP$001
                frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrig.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotHd()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 1 Then
                ' 20070111CAGP$003 /I
                'If oAlmacenDestino.CalcularVapor Then
                frmCapturaMedicionTanque.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenOrig.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value, True)
                If frmCapturaMedicionTanque.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotTanque()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
                'Else
                '    Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrig.Identificador, 0)
                '    oTanque.VerificarCapacidad()
                '    frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                '    '20060301CAGP$001
                '    frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrig.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                '    If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                '        Return True
                '    Else
                '        DestruyeMedicionFisicaEstacionario()
                '        Return False
                '    End If
                'End If
                ' 20070111CAGP$003 /F
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 1 Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenDest.Identificador, 0)
                oTanque.VerificarCapacidad()
                frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenDest.Text + "]"
                '20060301CAGP$001
                frmCapturaMedicionEstacionario.InicializaForma(0, True, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenDest.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotHd()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 4 Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrig.Identificador, 0)
                oTanque.VerificarCapacidad()
                frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                '20060301CAGP$001
                frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrig.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotHd()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 2 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 2 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 3 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 2 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 3 Then
                Return True
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 2 Then
                Return True
            Else
                Return False
            End If

        Else
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenDestino.CargarAlmacenGas()

            If oAlmacenDestino.TipoAlmacengas = 4 Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, cboAlmacenOrig.Identificador, 0)
                oTanque.VerificarCapacidad()
                frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, cboAlmacenOrig.Identificador, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$006
                If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotHd()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
                frmCapturaMedicionTanque.Text = "Lecturas físicas de gas por movimiento - [" + cboAlmacenOrig.Text + "]"
                frmCapturaMedicionTanque.InicializaForma(0, cboAlmacenOrig.Identificador, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, False, dtpFMovimiento.Value)
                If frmCapturaMedicionTanque.ShowDialog = DialogResult.OK Then
                    Return PermitirPorTotTanque()
                Else
                    DestruyeMedicionFisicaEstacionario()
                    Return False
                End If
            ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
                Return True
            ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
                Return True
            Else
                Return False
            End If
        End If

    End Function

    Private Sub AlmacenarMedicionFisica(ByVal MovEntrada As Integer, ByVal AlmDestino As Integer, ByVal MovSalida As Integer, ByVal AlmOrigen As Integer)
        If cboAlmacenDest.Identificador > 0 Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDest.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 4 Then
                frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 1 Then
                ' 20070111CAGP$003 /I
                'If oAlmacenDestino.CalcularVapor = False Then
                '    frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                'Else
                frmCapturaMedicionTanque.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                'End If
                DestruyeMedicionFisicaEstacionario()
                ' 20070111CAGP$003 /F
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 1 Then
                frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 4 Then
                frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 1 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 3 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 2 And oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            End If
        Else
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenDestino.TipoAlmacengas = 4 Then
                frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
                frmCapturaMedicionTanque.AlmacenarInformacion(MovEntrada, AlmDestino, MovSalida, AlmOrigen, "MOVIMIENTO")
                DestruyeMedicionFisicaEstacionario()
            ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
                MedicionFisicaPortatil(MovEntrada)
                MedicionFisicaPortatil(MovSalida)
            End If
        End If
    End Sub

    Private Sub ConsultaTotalizador()
        ' 20060303CAGP$004 /I
        If GLOBAL_IncrementaTotalizador = "1" Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 Then
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(0)
                oAutotanqueTurno.ConsultarAutotanqueTurno(0, oAlmacenOrigen.AlmacenGas, 0, 0)
                If Trim(oAutotanqueTurno.StatusBascula) <> "ABIERTO" Then
                    txtTotInicial.Text = oAutotanqueTurno.TotalizadorFinal.ToString("N2")
                Else
                    Dim Mensajes As New PortatilClasses.Mensaje(88, cboAlmacenOrig.Text)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    cboAlmacenOrig.PosicionarInicio()
                    ActiveControl = cboAlmacenOrig
                End If
            End If
        Else
            OperacionTotalizador(0)
        End If
        ' 20060303CAGP$004 /F
    End Sub

    Private Sub ActivaTotalizador()
        If cboAlmacenOrig.Text <> "" And cboAlmacenDest.Text <> "" Then
            Dim oAlmacenOrigen As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenOrig.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenOrigen.CargarAlmacenGas()
            Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, cboAlmacenDest.Identificador, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
            oAlmacenDestino.CargarAlmacenGas()
            If oAlmacenOrigen.TipoAlmacengas = 4 And (oAlmacenDestino.TipoAlmacengas = 2 Or oAlmacenDestino.TipoAlmacengas = 3) Then
                OperacionTotalizador(2)
            ElseIf oAlmacenOrigen.TipoAlmacengas = 4 And (oAlmacenDestino.TipoAlmacengas = 1 Or oAlmacenDestino.TipoAlmacengas = 4) Then
                OperacionTotalizador(1)
            Else
                OperacionTotalizador(0)
            End If
        End If
    End Sub

    Private Sub OperacionTotalizador(ByVal Operacion As Short)
        Select Case Operacion
            Case 0
                txtTotInicial.Clear()
                txtTotFinal.Clear()
                OperacionTotalizador(1)
            Case 1
                txtTotInicial.ReadOnly = True
                txtTotFinal.ReadOnly = True
            Case 2
                txtTotInicial.ReadOnly = True
                txtTotFinal.ReadOnly = False
        End Select
    End Sub

    Function ValidaTotalizador() As Boolean
        If txtTotInicial.ReadOnly And txtTotFinal.ReadOnly Then
            Return True
        ElseIf txtTotFinal.ReadOnly = False Then
            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                Dim TotInicial As Decimal = CType(txtTotInicial.Text, Decimal)
                Dim TotFinal As Decimal = CType(txtTotFinal.Text, Decimal)
                If TotInicial <= TotFinal Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        OperacionTotalizador(0)
        lblKilos.Text = "0"
        If cboAlmacenDest.Items.Count > 1 Then
            cboAlmacenDest.SelectedIndex = -1
            cboAlmacenDest.SelectedIndex = -1
        End If
        If cboAlmacenOrig.Items.Count > 1 Then
            cboAlmacenOrig.SelectedIndex = -1
            cboAlmacenOrig.SelectedIndex = -1
        End If
        If cboCorporativoDest.Items.Count > 1 Then
            cboCorporativoDest.SelectedIndex = -1
            cboCorporativoDest.SelectedIndex = -1
        End If
        If cboCorporativoOrig.Items.Count > 1 Then
            cboCorporativoOrig.SelectedIndex = -1
            cboCorporativoOrig.SelectedIndex = -1
        End If
    End Sub

    ' Verifica que el almacén origen y el almacén destino no sean el mismo
    Private Function CorporativoDiferente() As Boolean
        If cboCorporativoDest.Identificador = cboCorporativoOrig.Identificador Then
            Return False
        End If
        Return True
    End Function

    Private Function CorporativoDetalle(ByVal Corporativo As Integer) As Boolean
        Dim i As Integer
        Dim _Corporativo As Integer
        For i = 0 To GLOBAL_DetalleEmpresas.Count - 1
            Try
                _Corporativo = CType(GLOBAL_DetalleEmpresas(i), Integer)
                If _Corporativo = Corporativo Then
                    Return True
                End If
            Catch
                Return False
            End Try
        Next
        Return False
    End Function

    Private Sub HabilitarOrigen()
        If CType(GLOBAL_DetalleEmpresa, Short) < 2 Then
            EntradaSalida = False
            cboAlmacenDest.Enabled = False
        End If
    End Sub

    Private Sub HabilitarEntradaSalida()
        If CType(GLOBAL_DetalleEmpresa, Short) > 1 Then
            If cboCelulaDestino.Text <> "" And cboCelulaOrigen.Text <> "" Then
                If CorporativoDetalle(cboCelulaDestino.Identificador) And _
                CorporativoDetalle(cboCelulaOrigen.Identificador) And CorporativoDiferente() Then
                    EntradaSalida = True
                Else
                    EntradaSalida = False
                End If
            End If
        End If
    End Sub

    ' Habilita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If EntradaSalida Then
            If cboAlmacenDest.Text <> "" And cboAlmacenOrig.Text <> "" And _
               cboCorporativoDest.Text <> "" And CType(lblKilos.Text, Decimal) > 0 And _
               cboCorporativoOrig.Text <> "" And CorporativoDiferente() And ValidaTotalizador() Then
                btnAceptar.Enabled = True
            Else
                btnAceptar.Enabled = False
            End If
        Else
            If cboAlmacenOrig.Text <> "" And CType(lblKilos.Text, Decimal) > 0 And _
               cboCorporativoOrig.Text <> "" And CorporativoDiferente() And _
               cboCorporativoDest.Text <> "" And ValidaTotalizador() Then
                If cboCelulaDestino.Text = "" And cboCelulaDestino.Items.Count > 0 Then
                    btnAceptar.Enabled = False
                Else
                    btnAceptar.Enabled = True
                End If
            Else
                btnAceptar.Enabled = False
            End If
        End If
    End Sub

    ' Habilita los posibles valores del alamcén destino dependiendo de la selección del almacén origen
    Private Sub HabilitarAlmacenOrigen()
        Dim Posicion As Integer
        Posicion = cboAlmacenDest.SelectedIndex
        If cboAlmacenOrig.Text <> "" And cboCorporativoDest.Text <> "" And cboCelulaDestino.Text <> "2 Then" Then
            If cboAlmacenOrig.TipoProducto = 5 Then
                If cboAlmacenOrig.Movil Then
                    ' Muestra los almacenes de tipo portatil
                    'cboAlmacenDest.CargaDatos(6, GLOBAL_Usuario, cboCorporativoDest.Identificador)
                    cboAlmacenDest.CargaDatos(18, GLOBAL_Usuario, cboCelulaDestino.Identificador)
                Else
                    ' Muestra los almacenes Contenedores, Autotanque, Camion y Anden
                    'cboAlmacenDest.CargaDatos(5, GLOBAL_Usuario, cboCorporativoDest.Identificador)
                    cboAlmacenDest.CargaDatos(15, GLOBAL_Usuario, cboCelulaDestino.Identificador)
                End If

            Else
                ' Muestra los almacenes Autotanques y Contenedores
                'cboAlmacenDest.CargaDatos(9, GLOBAL_Usuario, cboCorporativoDest.Identificador)
                cboAlmacenDest.CargaDatos(14, GLOBAL_Usuario, cboCelulaDestino.Identificador)
            End If
        End If
        If Posicion < cboAlmacenDest.Items.Count Then
            cboAlmacenDest.SelectedIndex = Posicion
        End If
    End Sub

    ' Registra los productos del movimiento, dependiendo del almacén origen y destino
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
   ByVal TipoMovimiento As Integer)
        ' Salida de productos del almacen 5
        If TipoMovimiento = 5 And EntradaSalida Then
            ' Registra el producto enviado en kilos
            If cboAlmacenDest.TipoProducto <> 5 And cboAlmacenOrig.TipoProducto = 5 Then
                'ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Producto, CType(lblKilos.Text, Decimal))
                If cboAlmacenOrig.Movil Then
                    Dim Litros As Decimal = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Litros, Producto)
                Else
                    ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Producto, CType(lblKilos.Text, Decimal))
                End If
            End If
            ' Registra los productos contenidos en el panel en kilos
            If cboAlmacenDest.TipoProducto = 5 And cboAlmacenOrig.TipoProducto = 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
            End If
            ' Registra el producto enviado en litros
            If cboAlmacenDest.TipoProducto <> 5 And cboAlmacenOrig.TipoProducto <> 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal), Producto)
            End If
        End If
        If TipoMovimiento = 5 And EntradaSalida = False Then
            ' Registra el producto enviado en kilos
            If cboAlmacenOrig.TipoProducto = 5 Then
                'ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, Producto, CType(lblKilos.Text, Decimal))
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
            End If
            ' Registra el producto enviado en litros
            If cboAlmacenOrig.TipoProducto <> 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal), Producto)
            End If
        End If
        ' Entrada de productos del almacen 6
        If TipoMovimiento = 6 And EntradaSalida Then
            ' Registra los productos contenidos en el panel en kilos
            If cboAlmacenOrig.TipoProducto = 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)
            End If
            ' Registra el producto enviado en litros
            If cboAlmacenDest.TipoProducto <> 5 And cboAlmacenOrig.TipoProducto <> 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
            End If
        End If
        If TipoMovimiento = 6 And EntradaSalida = False Then
            If cboAlmacenOrig.TipoProducto = 5 Then
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen)     ' 20060617CAGP$013
            Else
                ProductoPanel.RegistraMovimientoProducto(Almacen, MovimientoAlmacen, CType(lblKilos.Text, Decimal))
            End If
        End If
    End Sub

    ' Realiza los movimientos originados por el traspaso
    Public Function RealizarMovimientos() As Boolean
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim KilosOrigen As Decimal
            Dim LitrosOrigen As Decimal
            Dim KilosDestino As Decimal
            Dim LitrosDestino As Decimal
            Dim FechaMov As DateTime
            Dim CelulaDestino As Integer
            If cboCelulaDestino.Text = "" Then
                CelulaDestino = 0
            Else
                CelulaDestino = cboCelulaDestino.Identificador
            End If

            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            If cboAlmacenDest.Text = "" Then
                If cboAlmacenOrig.TipoProducto = 5 Then
                    KilosOrigen = CType(lblKilos.Text, Decimal)
                    LitrosOrigen = KilosOrigen / CType(FactorDensidad, Decimal)
                Else
                    LitrosOrigen = CType(lblKilos.Text, Decimal)
                    KilosOrigen = LitrosOrigen * CType(FactorDensidad, Decimal)
                End If
                LitrosDestino = LitrosOrigen
                KilosDestino = KilosOrigen
            Else
                If cboAlmacenDest.TipoProducto = 5 Then
                    KilosDestino = CType(lblKilos.Text, Decimal)
                    LitrosDestino = KilosDestino / CType(FactorDensidad, Decimal)
                Else
                    LitrosDestino = CType(lblKilos.Text, Decimal)
                    KilosDestino = LitrosDestino * CType(FactorDensidad, Decimal)
                End If
                LitrosOrigen = LitrosDestino
                KilosOrigen = KilosDestino
            End If
            FechaMov = dtpFMovimiento.Value

            Dim CorporativoOrigen As Integer
            CorporativoOrigen = cboCorporativoOrig.Identificador '20060301CAGP$001

            '20060301CAGP$001 /I
            Dim oFolioMovimientoAlmacenS As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacenS.Registrar(0, cboAlmacenOrig.Identificador, 0, 6, 0)
            Dim oFolioMovimientoAlmacenE As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacenE.Registrar(3, 0, oFolioMovimientoAlmacenE.NDocumento, 5, cboCorporativoDest.Identificador)
            '20060301CAGP$001 /F

            Dim AlmacenDestino As Integer
            If EntradaSalida Then
                AlmacenDestino = cboAlmacenDest.Identificador
            Else
                AlmacenDestino = 0
                Producto = 1
            End If

            If AlmacenDestino > 0 Then
                If cboAlmacenOrig.Movil And cboAlmacenOrig.TipoProducto <> 5 Then
                    If cboAlmacenDest.TipoProducto = 5 Then
                        LitrosOrigen = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                        KilosOrigen = LitrosOrigen * CType(FactorDensidad, Decimal)
                    End If
                End If
            End If
            Dim oMovimientoAlmacenS As New cMovimientoAlmacen(0, 0, cboAlmacenOrig.Identificador, _
                                       FechaMov, KilosOrigen, LitrosOrigen, 5, FechaMov, oFolioMovimientoAlmacenS.NDocumento, _
                                           oFolioMovimientoAlmacenS.ClaseMovimientoAlmacen, _
                                           CorporativoOrigen, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            RegistraMovimientoProducto(cboAlmacenOrig.Identificador, oMovimientoAlmacenS.Identificador, 5)

            Dim oMovimientoAlmacenE As New cMovimientoAlmacen(0, 0, AlmacenDestino, _
                                       FechaMov, KilosDestino, LitrosDestino, 6, FechaMov, oFolioMovimientoAlmacenE.NDocumento, _
                                           oFolioMovimientoAlmacenE.ClaseMovimientoAlmacen, _
                                           cboCorporativoDest.Identificador, GLOBAL_Usuario, CelulaDestino)
            oMovimientoAlmacenE.CargaDatos()
            RegistraMovimientoProducto(AlmacenDestino, oMovimientoAlmacenE.Identificador, 6)



            Dim oMovimientoEntreAlmacenes As New cMovimientoEntreAlmacenes(0, AlmacenDestino, oMovimientoAlmacenE.Identificador, _
            cboAlmacenOrig.Identificador, oMovimientoAlmacenS.Identificador)


            oMovimientoEntreAlmacenes.CargaDatos()

            ' cagp
            If txtTotInicial.Text.Length > 0 And txtTotFinal.Text.Length > 0 Then
                ' Registra la carga en autotanque turno
                Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(2)
                oAutotanqueTurno.CargaDatos(dtpFMovimiento.Value.Year, 0, dtpFTraslado.Value.Date, 0, _
                                        cboAlmacenOrig.Celula, 1, 0, 1, 0, _
                                        oMovimientoAlmacenS.Identificador, cboAlmacenOrig.Identificador, True)
            End If
            'Llama a la funcion para almacenar "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                AlmacenarMedicionFisica(oMovimientoAlmacenE.Identificador, AlmacenDestino, oMovimientoAlmacenS.Identificador, cboAlmacenOrig.Identificador)
            End If

            ' 20060123CAGP$001 /I
            If GLOBAL_ImprimirFisicoTraslado = "1" Then
                Dim Impresoras As New Printing.PrinterSettings()
                pdImprimir.PrinterSettings = Impresoras
                If pdImprimir.ShowDialog = DialogResult.OK Then
                    ImprimirReporte(0, oMovimientoAlmacenS.Identificador, "ReporteTicketTraslado.rpt", pdImprimir.PrinterSettings.PrinterName)
                    ImprimirReporte(2, oMovimientoAlmacenS.Identificador, "ReporteTicketTrasladoFisico.rpt", pdImprimir.PrinterSettings.PrinterName)
                End If
            Else
                If GLOBAL_Imprimir = "1" Then
                    ImprimirReporte(0, oMovimientoAlmacenS.Identificador, "ReporteTicketTraslado.rpt", "")
                End If
            End If
            ' 20060123CAGP$001 /F

            oMovimientoEntreAlmacenes = Nothing
            oMovimientoAlmacenS = Nothing
            oMovimientoAlmacenE = Nothing
            oMovimientoAlmacenS = Nothing
            oMovimientoAlmacenE = Nothing
            Limpiar()
            ProductoPanel.BorrarDatos()
            ActiveControl = cboCorporativoOrig
            Cursor = Cursors.Default
        End If
    End Function

    Public Function VerificarExistenciasLitros(ByVal AlmacenOrigen As Integer, ByVal Cantidad As Decimal, _
    ByVal Producto As Integer) As Boolean
        Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(1, AlmacenOrigen, Producto, _
                                      Cantidad)
        VerificaExistencia.CargaDatos()
        If VerificaExistencia.Existencia = 0 Then
            Return False
        End If
        Return True
    End Function


    ' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    Private Function VerificarExistencias(ByVal Almacen As Integer, ByVal Cantidad As Decimal) As Boolean
        If EntradaSalida Then
            If cboAlmacenOrig.TipoProducto <> 5 And cboAlmacenDest.TipoProducto = 5 Then
                If cboAlmacenOrig.Movil Then
                    Dim Litros As Decimal = CType(txtTotFinal.Text, Decimal) - CType(txtTotInicial.Text, Decimal)
                    Return (VerificarExistenciasLitros(Almacen, Litros, Producto))
                Else
                    Return (ProductoPanel.VerificarExistenciasKilos(Almacen, Cantidad, Producto))
                End If
            Else
                Return (ProductoPanel.VerificarExistencias(Almacen, Cantidad, Producto))
            End If
        Else
            Return (ProductoPanel.VerificarExistencias(Almacen, Cantidad, Producto)) '20060301CAGP$001
        End If
    End Function

    '20060301CAGP$001 /I
    Private Function stockMinimo(ByVal AlmacenDestino As Integer) As Boolean
        If AlmacenDestino = 0 Then
            Return True
        Else
            Return ProductoPanel.StockMinimo(cboAlmacenDest.Identificador, cboAlmacenDest.TipoProducto)
        End If
    End Function
    '20060301CAGP$001 /F

    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos()
        '20060301CAGP$001 /I
        If VerificarExistencias(cboAlmacenOrig.Identificador, CType(lblKilos.Text, Decimal)) Then
            If stockMinimo(cboAlmacenDest.Identificador) Then
                If GLOBAL_MedicionFisica Then
                    If MedicionFisica() Then
                        RealizarMovimientos()
                    End If
                Else
                    RealizarMovimientos()
                End If
            Else
                Dim Mensajes As New PortatilClasses.Mensaje(5)
                MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = ProductoPanel.txtCantidad1
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(1)
            MessageBox.Show(Mensajes.Mensaje, "Transpasos almacen", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
        End If
        '20060301CAGP$001 /F
    End Sub

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacenOrig.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
            dtpFTraslado.Value = Fecha
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fechas mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = FechaActual()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Carga el producto del almacén
    Private Sub ProductoContenedor()
        ' 20060301CAGP$001 /I
        If cboAlmacenOrig.Text <> "" Then
            Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, cboAlmacenOrig.Identificador)
            oProductoContenedor.CargaDatos()
            Producto = oProductoContenedor.Identificador
            oProductoContenedor = Nothing
        End If
        ' 20060301CAGP$001 /F
    End Sub

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora(ByVal Impresora As String)
        ' 20060123CAGP$001 /I
        If Impresora = "" Then
            Dim Impresoras As New Printing.PrinterSettings()
            rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
        Else
            rptReporte.PrintOptions.PrinterName = Impresora
        End If
        ' 20060123CAGP$001 /F
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
            rptReporte.Load(GLOBAL_RutaReportes & "\" & NombreTicket) '20060123CAGP$001

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
                EstablecerImpresora(Impresora) '20060123CAGP$001
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

    ' verifica si al informacion ya ha sido verificada y/o aprobada
    ' 20060617CAGP$013
    Private Function InformacionVerificada() As Boolean
        Dim Res As Boolean = False
        If cboAlmacenOrig.Text <> "" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                    cboAlmacenOrig.Identificador, 0) ' 20060822CAGP$001
            If oMovimiento.RealizarMovimiento() = False Then
                Res = True
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFMovimiento
            End If
        End If
        If cboAlmacenDest.Text <> "" Then
            Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
                   cboAlmacenDest.Identificador, 0) ' 20060822CAGP$001
            If oMovimiento.RealizarMovimiento() = False Then
                Res = True
                Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = dtpFMovimiento
            End If
        End If
        Return Res
    End Function

    ' Inicialización de la forma
    Private Sub frmMovimientoTranspaso_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        ActiveControl = cboCorporativoOrig
        ValidarRangoFechas()
        Limpiar()
        cboCorporativoDest.CargaDatos(0)
        If cboCorporativoDest.Text <> "" Then
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoDest.Identificador, Short), 0, 0)
        End If
        cboCorporativoOrig.CargaDatos(0)
        cboCorporativoOrig.PosicionaCombo(GLOBAL_Empresa)
        If cboCorporativoOrig.Text <> "" Then
            'cboAlmacenOrig.CargaDatos(5, GLOBAL_Usuario, cboCorporativoOrig.Identificador)
            cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrig.Identificador, Short), 0, 0)
            If cboCelulaOrigen.Text <> "" Then
                cboAlmacenOrig.CargaDatos(15, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            End If
        End If

        ProductoContenedor()
        If cboAlmacenOrig.Text <> "" Then
            ProductoPanel.CargarProducto(cboAlmacenOrig.Identificador, cboAlmacenOrig.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenOrig.Identificador)
        End If
        HabilitarOrigen()
        Cursor = Cursors.Default
    End Sub

    ' Carga los datos del almacén origen dependiendo de la empresa origen seleccionada
    Private Sub cboCorporativoDest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCorporativoDest.SelectedIndexChanged
        If cboCorporativoDest.Focused And cboCorporativoDest.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            cboCelulaDestino.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoDest.Identificador, Short), 0, 0)
            HabilitarAlmacenOrigen()
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
        'HabilitarEntradaSalida()
    End Sub

    ' Carga los datos del almacén destino dependiendo de la empresa destino seleccionada
    Private Sub cboCorporativoOrig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCorporativoOrig.SelectedIndexChanged
        If cboCorporativoOrig.Focused And cboCorporativoOrig.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            'cboAlmacenOrig.CargaDatos(5, GLOBAL_Usuario, cboCorporativoOrig.Identificador)
            cboCelulaOrigen.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoOrig.Identificador, Short), 0, 0)
            'HabilitarEntradaSalida()
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los productos del almacén seleccionado
    Private Sub cboAlmacenOrig_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboAlmacenOrig.SelectedIndexChanged
        If cboAlmacenOrig.Focused And cboAlmacenOrig.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ProductoContenedor() ' 20060301CAGP$001
            ProductoPanel.CargarProducto(cboAlmacenOrig.Identificador, cboAlmacenOrig.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenOrig.Identificador)
            If cboAlmacenOrig.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
            HabilitarAceptar()
            lblKilos.Text = "0.00"
            HabilitarAlmacenOrigen()
            OperacionTotalizador(0)
            ActivaTotalizador()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Carga los productos del almacén origen seleccionado
    Private Sub cboAlmacenDest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenDest.SelectedIndexChanged
        If cboAlmacenDest.Focused And cboAlmacenDest.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            ' 20060301CAGP$001 /I
            ProductoPanel.CargarProducto(cboAlmacenDest.Identificador, cboAlmacenDest.TipoProducto)
            ProductoPanel.CargarExistencias(cboAlmacenDest.Identificador)
            If cboAlmacenDest.TipoProducto = 5 Then
                lblProducto.Text = "Kilos:"
            Else
                lblProducto.Text = "Litros:"
            End If
            ' 20060301CAGP$001 /F
            HabilitarAceptar()
            ActivaTotalizador()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Evento del control btnAceptar, registra la información pedida
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If InformacionVerificada() = False Then ' 20060617CAGP$013
            ValidarMovimientos()
        End If
    End Sub

    ' Evento del control lblKilos
    Private Sub lblKilos_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblKilos.TextChanged
        HabilitarAceptar()
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboCorporativoDest_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboCorporativoDest.KeyDown, cboAlmacenDest.KeyDown, cboCorporativoOrig.KeyDown, _
    cboAlmacenOrig.KeyDown, dtpFMovimiento.KeyDown, ProductoPanel.KeyDown, dtpFTraslado.KeyDown, _
    cboCelulaDestino.KeyDown, cboCelulaOrigen.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub txtTotInicial_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtTotInicial.KeyDown, txtTotFinal.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            Me.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando hay un cambio en los textBox del control ProductoPanel
    Private Sub ProductoPanel_CarmbioTexto() Handles ProductoPanel.CarmbioTexto
        lblKilos.Text = Format(ProductoPanel.SumarKilos(), "n")
        If cboAlmacenDest.Text <> "" And cboAlmacenOrig.Text <> "" Then
            If cboAlmacenOrig.TipoProducto = 1 And cboAlmacenDest.TipoProducto = 1 Then
                If txtTotInicial.Text.Length > 0 Then
                    txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal) + ProductoPanel.SumarKilos).ToString("N2")
                End If
            End If
        End If
        If cboAlmacenDest.Text = "" And cboAlmacenOrig.Text <> "" Then
            If cboAlmacenOrig.TipoProducto = 1 Then
                If txtTotInicial.Text.Length > 0 Then
                    txtTotFinal.Text = (CType(txtTotInicial.Text, Decimal) + ProductoPanel.SumarKilos).ToString("N2")
                End If
            End If
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub frmMovimientoTraspaso_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(28)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If cboAlmacenDest.Text <> "" Then
        '    Dim ofrmExistencias As New frmExistencias(cboAlmacenDest.Identificador, cboAlmacenDest.Text)
        '    ofrmExistencias.ShowDialog()
        '    ofrmExistencias = Nothing
        'Else
        '    Dim Mensajes As New PortatilClasses.Mensaje(69)
        '    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End If
    End Sub


    Private Sub cboAlmacenOrig_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenOrig.Leave
        If cboAlmacenOrig.Text <> "" Then
            ConsultaTotalizador()
        End If
    End Sub

    Private Sub cboCelulaDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelulaDestino.SelectedIndexChanged
        If cboCelulaDestino.Focused And cboCelulaDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            HabilitarAlmacenOrigen()
            HabilitarEntradaSalida()
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub cboCelulaOrigen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelulaOrigen.SelectedIndexChanged
        If cboCelulaOrigen.Focused And cboCelulaOrigen.Text <> "" Then
            Cursor = Cursors.WaitCursor
            Refresh()
            cboAlmacenOrig.CargaDatos(15, GLOBAL_Usuario, cboCelulaOrigen.Identificador)
            HabilitarEntradaSalida()
            HabilitarAceptar()
            Cursor = Cursors.Default
        End If
    End Sub
End Class
