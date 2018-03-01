'Modificó: Carlos Francisco Sánchez Lavariega
'Fecha: 25/11/2005
'Descripción: Se corrigió el error impreso en el documento Folio GM - 0001, debido a un error
'             en el campo Fecha de movimiento
'Identificador de cambios: 20051125CFSL#001


' Registrar y modifca la información de lso embarques, al modificar un embarque no se activan varios registros
' debido a que estos registros afecta directamente los inventarios, estos registros no se pueden modificar para
' esto es neecsario la cancelación del movimiento

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 27/12/2005
'Motivo: Se aumentaron algunos datos en la interfaz como porcentaje Pemex, Transportandora
'Identificador de cmabios: 20051227CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 05 de Mayo del 2006
' Motivo: Se aumento los parametros regsitrados en bascula
' Identificador de cambios: 20060505CAGP$002

' Modifico: Claudia Aurora García Patiño
' Fecha: 16 de Mayo del 2006
' Motivo: Se aumentaron unas lineas para no cargar todos los almacenes
' Identificador de cambios: 20060515CAGP$001

' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$002

'Modifico: Claudia Aurora García Patiño
'Fecha: 19/07/2006
'Motivo: Se agrego un parametro 
'Identificador de cambios: 20060719CAGP$002

'Modifico: Claudia Aurora García Patiño
'Fecha: 24/07/2006
'Motivo: Se quito una condicion, para que acepte el registro de embarqes que aun no han sido destarado
'Identificador de cambios: 20060724CAGP$001

'Modifico: Claudia Aurora García Patiño
'Fecha: 15/08/2006
'Motivo: Inabilito el campo de empresa facturada para la opcion modificar
'Identificador de cambios: 20060815CAGP$002

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 07/11/2006
'Motivo: Se valido el sistema para que no acepte un embarque que no ha sido pesado
'Identificador de cambios: 20061107CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 23/01/2007
'Motivo: Se modifico algunas condiciones
'Identificador de cambios: 20070123CAGP$001

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports GuardarArchivos
Imports System.Collections.Generic

Public Class frmEmbarque
    Inherits System.Windows.Forms.Form
    Private Producto As Integer
    Public Operacion As String
    Public Embarque As Integer
    Private FactorDensidad As String
    Private Titulo As String
    Private TipoMovimiento As Short
    Private DatosSalvados As Boolean
    Private NumEnter As Short

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Private _Placas As String = ""
    Friend WithEvents cboProveedorGas As PortatilClasses.Combo.ComboBase
    Friend WithEvents lblProveedorGas As System.Windows.Forms.Label
    Friend WithEvents btnAdjuntarGuias As System.Windows.Forms.Button
    Private _Operador As String = ""
    Private _lstGuiaEmbarques As List(Of GuardarArchivos.GuiaEmbarqueMetodos)    

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        _lstGuiaEmbarques = New List(Of GuardarArchivos.GuiaEmbarqueMetodos)

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents txtNumeroEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents cboCorporativoDestino As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboCorporativoFacturar As PortatilClasses.Combo.ComboCorporativo
    Friend WithEvents cboAlmacen As PortatilClasses.Combo.ComboAlmacen
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents txtPG As System.Windows.Forms.TextBox
    Friend WithEvents dtpFRecepcion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFEmbarque As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboTransportadora As PortatilClasses.Combo.ComboBase
    Friend WithEvents cboOrigen As PortatilClasses.Combo.ComboBase
    Friend WithEvents dtpHFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpHInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtPorcentaje As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtPesoVacio As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtPesoLleno As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtTicket As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtTotalizadorFMs As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtTotalizadorIMs As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents cboCelula As PortatilClasses.Combo.ComboBase
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCapacidadPG As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtLitros100 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtLitrosPemex As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtKilosPemex As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtGarza As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEmbarque))
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.cboProveedorGas = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.lblProveedorGas = New System.Windows.Forms.Label()
        Me.txtCapacidadPG = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboCelula = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.Label45 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.cboOrigen = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.cboTransportadora = New PortatilClasses.Combo.ComboBase(Me.components)
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.txtPG = New System.Windows.Forms.TextBox()
        Me.dtpFRecepcion = New System.Windows.Forms.DateTimePicker()
        Me.dtpFEmbarque = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtNumeroEmbarque = New System.Windows.Forms.TextBox()
        Me.cboCorporativoDestino = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboCorporativoFacturar = New PortatilClasses.Combo.ComboCorporativo()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.cboAlmacen = New PortatilClasses.Combo.ComboAlmacen()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtGarza = New System.Windows.Forms.TextBox()
        Me.txtKilosPemex = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtLitrosPemex = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtLitros100 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalizadorFMs = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtTotalizadorIMs = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtPesoVacio = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtPesoLleno = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtTicket = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.dtpHFinal = New System.Windows.Forms.DateTimePicker()
        Me.dtpHInicio = New System.Windows.Forms.DateTimePicker()
        Me.txtPorcentaje = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAdjuntarGuias = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Location = New System.Drawing.Point(555, 379)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(75, 23)
        Me.btnSiguiente.TabIndex = 1
        Me.btnSiguiente.Text = "&Siguiente>>"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(555, 57)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(555, 25)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(8, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(528, 454)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.TabStop = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.btnAdjuntarGuias)
        Me.TabPage1.Controls.Add(Me.cboProveedorGas)
        Me.TabPage1.Controls.Add(Me.lblProveedorGas)
        Me.TabPage1.Controls.Add(Me.txtCapacidadPG)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.cboCelula)
        Me.TabPage1.Controls.Add(Me.Label45)
        Me.TabPage1.Controls.Add(Me.dtpFMovimiento)
        Me.TabPage1.Controls.Add(Me.Label44)
        Me.TabPage1.Controls.Add(Me.cboOrigen)
        Me.TabPage1.Controls.Add(Me.cboTransportadora)
        Me.TabPage1.Controls.Add(Me.txtPlacas)
        Me.TabPage1.Controls.Add(Me.txtPG)
        Me.TabPage1.Controls.Add(Me.dtpFRecepcion)
        Me.TabPage1.Controls.Add(Me.dtpFEmbarque)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Label14)
        Me.TabPage1.Controls.Add(Me.Label15)
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.Label18)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtNumeroEmbarque)
        Me.TabPage1.Controls.Add(Me.cboCorporativoDestino)
        Me.TabPage1.Controls.Add(Me.Label20)
        Me.TabPage1.Controls.Add(Me.cboCorporativoFacturar)
        Me.TabPage1.Controls.Add(Me.Label21)
        Me.TabPage1.Controls.Add(Me.cboAlmacen)
        Me.TabPage1.Controls.Add(Me.Label22)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(520, 428)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Embarque"
        Me.ToolTip1.SetToolTip(Me.TabPage1, "Información del embarque")
        '
        'cboProveedorGas
        '
        Me.cboProveedorGas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProveedorGas.Location = New System.Drawing.Point(158, 105)
        Me.cboProveedorGas.Name = "cboProveedorGas"
        Me.cboProveedorGas.Size = New System.Drawing.Size(216, 21)
        Me.cboProveedorGas.TabIndex = 89
        '
        'lblProveedorGas
        '
        Me.lblProveedorGas.AutoSize = True
        Me.lblProveedorGas.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblProveedorGas.Location = New System.Drawing.Point(14, 110)
        Me.lblProveedorGas.Name = "lblProveedorGas"
        Me.lblProveedorGas.Size = New System.Drawing.Size(69, 13)
        Me.lblProveedorGas.TabIndex = 90
        Me.lblProveedorGas.Text = "Proveedor:"
        Me.lblProveedorGas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCapacidadPG
        '
        Me.txtCapacidadPG.Location = New System.Drawing.Point(158, 355)
        Me.txtCapacidadPG.MaxLength = 10
        Me.txtCapacidadPG.Name = "txtCapacidadPG"
        Me.txtCapacidadPG.Size = New System.Drawing.Size(216, 20)
        Me.txtCapacidadPG.TabIndex = 11
        Me.txtCapacidadPG.Text = "TxtNumeroDecimal3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 359)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 13)
        Me.Label6.TabIndex = 88
        Me.Label6.Text = "Capacidad P.G. (Lts):"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(158, 132)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(216, 21)
        Me.cboCelula.TabIndex = 3
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label45.Location = New System.Drawing.Point(14, 137)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(117, 13)
        Me.Label45.TabIndex = 87
        Me.Label45.Text = "Destino según guía:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(158, 187)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 5
        Me.dtpFMovimiento.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label44.Location = New System.Drawing.Point(14, 191)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(114, 13)
        Me.Label44.TabIndex = 86
        Me.Label44.Text = "Fecha movimiento:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.Location = New System.Drawing.Point(158, 299)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(216, 21)
        Me.cboOrigen.TabIndex = 9
        '
        'cboTransportadora
        '
        Me.cboTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransportadora.Location = New System.Drawing.Point(158, 271)
        Me.cboTransportadora.Name = "cboTransportadora"
        Me.cboTransportadora.Size = New System.Drawing.Size(216, 21)
        Me.cboTransportadora.TabIndex = 8
        '
        'txtPlacas
        '
        Me.txtPlacas.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPlacas.Location = New System.Drawing.Point(158, 383)
        Me.txtPlacas.MaxLength = 12
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.Size = New System.Drawing.Size(216, 20)
        Me.txtPlacas.TabIndex = 12
        Me.txtPlacas.Text = "TEXTBOX3"
        '
        'txtPG
        '
        Me.txtPG.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPG.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtPG.Location = New System.Drawing.Point(158, 327)
        Me.txtPG.MaxLength = 25
        Me.txtPG.Name = "txtPG"
        Me.txtPG.Size = New System.Drawing.Size(216, 20)
        Me.txtPG.TabIndex = 10
        Me.txtPG.Text = "TEXTBOX6"
        '
        'dtpFRecepcion
        '
        Me.dtpFRecepcion.CalendarFont = New System.Drawing.Font("Tahoma", 8.0!)
        Me.dtpFRecepcion.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFRecepcion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFRecepcion.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFRecepcion.Location = New System.Drawing.Point(158, 243)
        Me.dtpFRecepcion.Name = "dtpFRecepcion"
        Me.dtpFRecepcion.Size = New System.Drawing.Size(216, 21)
        Me.dtpFRecepcion.TabIndex = 7
        Me.dtpFRecepcion.Value = New Date(2004, 7, 1, 20, 34, 7, 477)
        '
        'dtpFEmbarque
        '
        Me.dtpFEmbarque.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFEmbarque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFEmbarque.Location = New System.Drawing.Point(158, 215)
        Me.dtpFEmbarque.Name = "dtpFEmbarque"
        Me.dtpFEmbarque.Size = New System.Drawing.Size(216, 21)
        Me.dtpFEmbarque.TabIndex = 6
        Me.dtpFEmbarque.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(14, 387)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Placas:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(14, 331)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 13)
        Me.Label12.TabIndex = 83
        Me.Label12.Text = "Número de P.G.:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(14, 303)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(79, 13)
        Me.Label14.TabIndex = 82
        Me.Label14.Text = "Procedencia:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(14, 275)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(99, 13)
        Me.Label15.TabIndex = 81
        Me.Label15.Text = "Transportadora:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(14, 247)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 13)
        Me.Label17.TabIndex = 79
        Me.Label17.Text = "Fecha llegada:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(14, 219)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(87, 13)
        Me.Label18.TabIndex = 78
        Me.Label18.Text = "Fecha de guía:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(14, 163)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(98, 13)
        Me.Label19.TabIndex = 77
        Me.Label19.Text = "Número de guía:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtNumeroEmbarque
        '
        Me.txtNumeroEmbarque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroEmbarque.Location = New System.Drawing.Point(158, 159)
        Me.txtNumeroEmbarque.MaxLength = 10
        Me.txtNumeroEmbarque.Name = "txtNumeroEmbarque"
        Me.txtNumeroEmbarque.Size = New System.Drawing.Size(216, 20)
        Me.txtNumeroEmbarque.TabIndex = 4
        Me.txtNumeroEmbarque.Text = "TEXTBOX8"
        '
        'cboCorporativoDestino
        '
        Me.cboCorporativoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoDestino.ItemHeight = 13
        Me.cboCorporativoDestino.Location = New System.Drawing.Point(158, 24)
        Me.cboCorporativoDestino.Name = "cboCorporativoDestino"
        Me.cboCorporativoDestino.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoDestino.TabIndex = 0
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(14, 28)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(107, 13)
        Me.Label20.TabIndex = 75
        Me.Label20.Text = "Empresa destino :"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboCorporativoFacturar
        '
        Me.cboCorporativoFacturar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCorporativoFacturar.ItemHeight = 13
        Me.cboCorporativoFacturar.Location = New System.Drawing.Point(158, 81)
        Me.cboCorporativoFacturar.Name = "cboCorporativoFacturar"
        Me.cboCorporativoFacturar.Size = New System.Drawing.Size(216, 21)
        Me.cboCorporativoFacturar.TabIndex = 2
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(14, 85)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(118, 13)
        Me.Label21.TabIndex = 73
        Me.Label21.Text = "Empresa a facturar:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAlmacen
        '
        Me.cboAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacen.ItemHeight = 13
        Me.cboAlmacen.Location = New System.Drawing.Point(158, 52)
        Me.cboAlmacen.Name = "cboAlmacen"
        Me.cboAlmacen.Size = New System.Drawing.Size(216, 21)
        Me.cboAlmacen.TabIndex = 1
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(14, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(99, 13)
        Me.Label22.TabIndex = 72
        Me.Label22.Text = "Almacén de gas:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtGarza)
        Me.TabPage2.Controls.Add(Me.txtKilosPemex)
        Me.TabPage2.Controls.Add(Me.txtLitrosPemex)
        Me.TabPage2.Controls.Add(Me.txtLitros100)
        Me.TabPage2.Controls.Add(Me.txtOperador)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtTotalizadorFMs)
        Me.TabPage2.Controls.Add(Me.txtTotalizadorIMs)
        Me.TabPage2.Controls.Add(Me.Label42)
        Me.TabPage2.Controls.Add(Me.Label41)
        Me.TabPage2.Controls.Add(Me.Label33)
        Me.TabPage2.Controls.Add(Me.txtPesoVacio)
        Me.TabPage2.Controls.Add(Me.txtPesoLleno)
        Me.TabPage2.Controls.Add(Me.txtTicket)
        Me.TabPage2.Controls.Add(Me.Label35)
        Me.TabPage2.Controls.Add(Me.Label34)
        Me.TabPage2.Controls.Add(Me.Label43)
        Me.TabPage2.Controls.Add(Me.dtpHFinal)
        Me.TabPage2.Controls.Add(Me.dtpHInicio)
        Me.TabPage2.Controls.Add(Me.txtPorcentaje)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(520, 428)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Medición PG"
        Me.ToolTip1.SetToolTip(Me.TabPage2, "Información de las mediciones realizadas al PG del embarque")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 364)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Número de Garza:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGarza
        '
        Me.txtGarza.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtGarza.Location = New System.Drawing.Point(158, 360)
        Me.txtGarza.MaxLength = 3
        Me.txtGarza.Name = "txtGarza"
        Me.txtGarza.Size = New System.Drawing.Size(216, 20)
        Me.txtGarza.TabIndex = 12
        Me.txtGarza.Text = "TEXTBOX1"
        '
        'txtKilosPemex
        '
        Me.txtKilosPemex.Location = New System.Drawing.Point(158, 80)
        Me.txtKilosPemex.MaxLength = 10
        Me.txtKilosPemex.Name = "txtKilosPemex"
        Me.txtKilosPemex.Size = New System.Drawing.Size(216, 20)
        Me.txtKilosPemex.TabIndex = 2
        Me.txtKilosPemex.Text = "TxtNumeroDecimal3"
        '
        'txtLitrosPemex
        '
        Me.txtLitrosPemex.Location = New System.Drawing.Point(158, 52)
        Me.txtLitrosPemex.MaxLength = 10
        Me.txtLitrosPemex.Name = "txtLitrosPemex"
        Me.txtLitrosPemex.Size = New System.Drawing.Size(216, 20)
        Me.txtLitrosPemex.TabIndex = 1
        Me.txtLitrosPemex.Text = "TxtNumeroDecimal3"
        '
        'txtLitros100
        '
        Me.txtLitros100.Location = New System.Drawing.Point(158, 24)
        Me.txtLitros100.MaxLength = 10
        Me.txtLitros100.Name = "txtLitros100"
        Me.txtLitros100.Size = New System.Drawing.Size(216, 20)
        Me.txtLitros100.TabIndex = 0
        Me.txtLitros100.Text = "TxtNumeroDecimal3"
        '
        'txtOperador
        '
        Me.txtOperador.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtOperador.Location = New System.Drawing.Point(158, 332)
        Me.txtOperador.MaxLength = 40
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.Size = New System.Drawing.Size(348, 20)
        Me.txtOperador.TabIndex = 11
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 336)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(95, 13)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Nombre operador:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTotalizadorFMs
        '
        Me.txtTotalizadorFMs.Location = New System.Drawing.Point(158, 276)
        Me.txtTotalizadorFMs.MaxLength = 10
        Me.txtTotalizadorFMs.Name = "txtTotalizadorFMs"
        Me.txtTotalizadorFMs.Size = New System.Drawing.Size(216, 20)
        Me.txtTotalizadorFMs.TabIndex = 9
        Me.txtTotalizadorFMs.Text = "TxtNumeroDecimal3"
        '
        'txtTotalizadorIMs
        '
        Me.txtTotalizadorIMs.Location = New System.Drawing.Point(158, 304)
        Me.txtTotalizadorIMs.MaxLength = 10
        Me.txtTotalizadorIMs.Name = "txtTotalizadorIMs"
        Me.txtTotalizadorIMs.Size = New System.Drawing.Size(216, 20)
        Me.txtTotalizadorIMs.TabIndex = 10
        Me.txtTotalizadorIMs.Text = "TxtNumeroDecimal2"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(14, 280)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(139, 13)
        Me.Label42.TabIndex = 98
        Me.Label42.Text = "Totalizador final masímetro:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label41
        '
        Me.Label41.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(14, 308)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(144, 13)
        Me.Label41.TabIndex = 97
        Me.Label41.Text = "Totalizador inicial masímetro:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(14, 196)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(78, 13)
        Me.Label33.TabIndex = 94
        Me.Label33.Text = "Ticket báscula:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPesoVacio
        '
        Me.txtPesoVacio.Location = New System.Drawing.Point(158, 248)
        Me.txtPesoVacio.MaxLength = 12
        Me.txtPesoVacio.Name = "txtPesoVacio"
        Me.txtPesoVacio.Size = New System.Drawing.Size(216, 20)
        Me.txtPesoVacio.TabIndex = 8
        Me.txtPesoVacio.Text = "TxtNumeroEntero11"
        '
        'txtPesoLleno
        '
        Me.txtPesoLleno.Location = New System.Drawing.Point(158, 220)
        Me.txtPesoLleno.MaxLength = 12
        Me.txtPesoLleno.Name = "txtPesoLleno"
        Me.txtPesoLleno.Size = New System.Drawing.Size(216, 20)
        Me.txtPesoLleno.TabIndex = 7
        Me.txtPesoLleno.Text = "TxtNumeroEntero10"
        '
        'txtTicket
        '
        Me.txtTicket.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTicket.Location = New System.Drawing.Point(158, 192)
        Me.txtTicket.MaxLength = 10
        Me.txtTicket.Name = "txtTicket"
        Me.txtTicket.Size = New System.Drawing.Size(216, 20)
        Me.txtTicket.TabIndex = 6
        Me.txtTicket.Text = "TEXTBOX1"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(14, 252)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(85, 13)
        Me.Label35.TabIndex = 93
        Me.Label35.Text = "Peso tara vacío:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(14, 224)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(82, 13)
        Me.Label34.TabIndex = 92
        Me.Label34.Text = "Peso tara lleno:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label43.Location = New System.Drawing.Point(14, 84)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(105, 13)
        Me.Label43.TabIndex = 86
        Me.Label43.Text = "Kilos guía Pemex:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpHFinal
        '
        Me.dtpHFinal.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHFinal.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHFinal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHFinal.Location = New System.Drawing.Point(158, 164)
        Me.dtpHFinal.Name = "dtpHFinal"
        Me.dtpHFinal.Size = New System.Drawing.Size(216, 21)
        Me.dtpHFinal.TabIndex = 5
        Me.dtpHFinal.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'dtpHInicio
        '
        Me.dtpHInicio.AllowDrop = True
        Me.dtpHInicio.CalendarFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHInicio.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpHInicio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpHInicio.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpHInicio.Location = New System.Drawing.Point(158, 136)
        Me.dtpHInicio.Name = "dtpHInicio"
        Me.dtpHInicio.Size = New System.Drawing.Size(216, 21)
        Me.dtpHInicio.TabIndex = 4
        Me.dtpHInicio.Value = New Date(2004, 7, 1, 20, 34, 7, 497)
        '
        'txtPorcentaje
        '
        Me.txtPorcentaje.Location = New System.Drawing.Point(158, 108)
        Me.txtPorcentaje.MaxLength = 2
        Me.txtPorcentaje.Name = "txtPorcentaje"
        Me.txtPorcentaje.Size = New System.Drawing.Size(216, 20)
        Me.txtPorcentaje.TabIndex = 3
        Me.txtPorcentaje.Text = "TxtNumeroEntero3"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(14, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 13)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "Hora final descarga:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(14, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(124, 13)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "Hora inicio descarga:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(14, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 13)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Porcentaje guía Pemex:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(14, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "Litros guía Pemex:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(14, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "Litros al 100%:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(32, 72)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(0, 13)
        Me.Label25.TabIndex = 90
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(32, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 13)
        Me.Label24.TabIndex = 89
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(32, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(0, 13)
        Me.Label23.TabIndex = 88
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAdjuntarGuias
        '
        Me.btnAdjuntarGuias.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.btnAdjuntarGuias.Location = New System.Drawing.Point(380, 159)
        Me.btnAdjuntarGuias.Name = "btnAdjuntarGuias"
        Me.btnAdjuntarGuias.Size = New System.Drawing.Size(33, 22)
        Me.btnAdjuntarGuias.TabIndex = 91
        Me.btnAdjuntarGuias.Text = ". . ."
        Me.btnAdjuntarGuias.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdjuntarGuias.UseVisualStyleBackColor = True
        '
        'frmEmbarque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(642, 463)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnSiguiente)
        Me.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmEmbarque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Embarque"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Crea la forma de Captura de medicion fisica "CODIGO PACO"
    Dim frmCaptura As New MedicionFisica.frmMedicionEmbarque()

    'Funcion de la medicion fisica "CODIGO PACO"
    Function MedicionFisica() As Boolean
        Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(3, 0, txtPG.Text, "", 0, 0, _
                               CType(cboTransportadora.Identificador, Short))
        oTanque.VerificarCapacidad()
        frmCaptura.Text = "Lecturas físicas de gas por movimiento - [del embarque " + oTanque.NumeroTanque + " al " + cboAlmacen.Text + "]"
        frmCaptura.InicializaForma(0, txtPG.Text, oTanque.Tanque, CType(oTanque.Capacidad, Integer), CType(cboTransportadora.Identificador, Short), cboAlmacen.Identificador, 0, GLOBAL_Usuario, 0, GLOBAL_IDEmpleado, dtpHInicio.Value, dtpHFinal.Value, dtpFMovimiento.Value)
        If frmCaptura.ShowDialog = DialogResult.OK Then
            Return True
        Else
            Return False
        End If
    End Function

    '20051227CAGP$001 /I
    Private Sub PosicionaCombo()
        ' Temporal
        cboOrigen.PosicionaCombo(8)
        ' Temporal
        cboTransportadora.PosicionaCombo(1)
    End Sub
    '20051227CAGP$001 /F

    ' Limpia los controles de la forma
    Private Sub Limpiar()
        btnAceptar.Enabled = False
        If cboCorporativoFacturar.Items.Count > 1 Then
            cboCorporativoFacturar.SelectedIndex = -1
            cboCorporativoFacturar.SelectedIndex = -1
        End If
        If cboCorporativoDestino.Items.Count > 1 Then
            cboCorporativoDestino.SelectedIndex = -1
            cboCorporativoDestino.SelectedIndex = -1
        End If
        If cboAlmacen.Items.Count > 1 Then
            cboAlmacen.SelectedIndex = -1
            cboAlmacen.SelectedIndex = -1
        End If
        If cboTransportadora.Items.Count > 1 Then
            cboTransportadora.SelectedIndex = -1
            cboTransportadora.SelectedIndex = -1
        End If
        If cboOrigen.Items.Count > 1 Then
            cboOrigen.SelectedIndex = -1
            cboOrigen.SelectedIndex = -1
        End If
        If cboCelula.Items.Count > 1 Then
            cboCelula.SelectedIndex = -1
            cboCelula.SelectedIndex = -1
        End If
        txtNumeroEmbarque.Clear()
        txtPG.Clear()
        txtPlacas.Clear()
        txtOperador.Clear()
        txtLitros100.Clear()
        txtLitrosPemex.Clear()
        '20051227CAGP$001 /I
        txtPorcentaje.Text = "90"
        '20051227CAGP$001 /F
        txtTicket.Clear()
        txtPesoLleno.Clear()
        txtPesoVacio.Clear()
        txtTotalizadorFMs.Clear()
        txtTotalizadorIMs.Clear()
        txtKilosPemex.Clear()
        txtCapacidadPG.Clear()
        txtCapacidadPG.ReadOnly = True
        DatosSalvados = False
        txtGarza.Clear()
        If cboProveedorGas.Items.Count > 1 Then
            cboProveedorGas.SelectedIndex = -1
            cboProveedorGas.SelectedIndex = -1
        End If
    End Sub

    Private Sub RegistrarPG()
        If Not txtCapacidadPG.ReadOnly Then
            Dim Capacidad As Integer
            Capacidad = CType(txtCapacidadPG.Text, Integer)
            Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(2, 0, txtPG.Text, txtPG.Text, Capacidad, 0, _
                               CType(cboTransportadora.Identificador, Short), txtPlacas.Text, txtOperador.Text)
            oTanque.RegistrarModificarEliminar()
        Else
            If _Placas <> txtPlacas.Text Or _Operador <> txtOperador.Text Then
                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(5, 0, txtPG.Text, txtPG.Text, 0, 0, _
                               CType(cboTransportadora.Identificador, Short), txtPlacas.Text, txtOperador.Text)
                oTanque.RegistrarModificarEliminar()
            End If
        End If

    End Sub

    Private Sub BuscarPG()
        If txtPG.Text <> "" And cboTransportadora.Text <> "" And NumEnter = 1 Then
            Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(3, 0, txtPG.Text, "", 0, 0, _
                               CType(cboTransportadora.Identificador, Short))
            oTanque.VerificarCapacidad()
            If oTanque.NumeroTanque = "" Then
                ' Dar del alta la capacidad del tanque
                Dim Mensajes As New PortatilClasses.Mensaje(76)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtCapacidadPG.ReadOnly = False
                ActiveControl = txtCapacidadPG
                HabilitarAceptar()
            Else
                txtCapacidadPG.Clear()
                txtCapacidadPG.Text = CType(oTanque.Capacidad, String)
                txtPlacas.Clear()
                txtPlacas.Text = oTanque.Placas
                If oTanque.Placas.Length > 0 Then
                    _Placas = oTanque.Placas
                End If
                txtOperador.Clear()
                txtOperador.Text = oTanque.Operador
                If oTanque.Operador.Length > 0 Then
                    _Operador = oTanque.Operador
                End If
                CalcularCapacidadal90()
                txtCapacidadPG.ReadOnly = True
                ActiveControl = txtPlacas
                HabilitarAceptar()
            End If
            'NumEnter = 2
        End If
    End Sub

    Private Sub CalcularTipoMovimiento()
        If cboCorporativoDestino.Identificador = cboCorporativoFacturar.Identificador Then
            If cboAlmacen.Celula = cboCelula.Identificador Then
                TipoMovimiento = 10
            Else
                TipoMovimiento = 12
            End If
        Else
            TipoMovimiento = 14
        End If
    End Sub

    Private Sub HabilitarCelula()
        If cboCorporativoDestino.Text <> "" And cboCorporativoFacturar.Text <> "" Then
            If GLOBAL_PlantaUnica = "0" Then
                If cboCorporativoDestino.Identificador <> cboCorporativoFacturar.Identificador Then
                    cboCelula.Enabled = True
                Else
                    cboCelula.Enabled = True
                    If cboCelula.Text = "" And cboCelula.Items.Count > 0 And cboAlmacen.Text <> "" Then
                        cboCelula.PosicionaCombo(cboAlmacen.Celula)
                    End If
                End If
            Else
                cboCelula.Enabled = True
                If cboCelula.Items.Count > 0 And cboAlmacen.Text <> "" Then
                    cboCelula.PosicionaCombo(cboAlmacen.Celula)
                End If
                'cboCelula.Enabled = False
            End If
        End If
    End Sub

    ' Hablita el boton aceptar si los controles necesarios son llenados
    Private Sub HabilitarAceptar()
        If cboCorporativoFacturar.Text <> "" And cboCorporativoDestino.Text <> "" And cboAlmacen.Text <> "" And _
        txtNumeroEmbarque.Text <> "" And cboTransportadora.Text <> "" And cboOrigen.Text <> "" And txtPG.Text <> "" And _
        txtPlacas.Text <> "" And txtLitros100.Text <> "" And txtLitrosPemex.Text <> "" And txtPorcentaje.Text <> "" And _
        txtKilosPemex.Text <> "" And (txtCapacidadPG.ReadOnly = True Or txtCapacidadPG.Text <> "") Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Estable la impresoras predeterminada al informe
    Private Sub EstablecerImpresora()
        Dim Impresoras As New Printing.PrinterSettings()
        rptReporte.PrintOptions.PrinterName = Impresoras.PrinterName
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

    ' Manda al procedimientos los valores de los parametros e imprime el ticket de trasiego
    Private Sub ImprimirReporte(ByVal Configuracion As Integer, ByVal MovimientoAlmacen As Integer)
        Dim crParameterValues As ParameterValues
        Dim crParameterDiscreteValue As ParameterDiscreteValue
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition

        Try
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketTraspaso.rpt")

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
                EstablecerImpresora()
                rptReporte.PrintToPrinter(1, False, 0, 0)
            Catch exc As Exception
                Dim Mensajes As New PortatilClasses.Mensaje(12)
                MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Catch exc As Exception
            Dim Mensajes As New PortatilClasses.Mensaje(12)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    ' 20060719CAGP$002 /I
    ' Verifica si el embarque a registrar o modificar no existe
    Private Sub ExisteEmbarque(ByVal sender As Object)
        If cboAlmacen.Text <> "" And txtNumeroEmbarque.Text <> "" And txtPG.Text <> "" And NumEnter = 1 Then ' 20070123CAGP$001
            If GLOBAL_BasculaInstalada = "0" Then
                Dim oExisteEmbarque As New PortatilClasses.Consulta.cExisteEmbarque(0)
                oExisteEmbarque.CargarDatos(cboAlmacen.Identificador, txtPG.Text, txtNumeroEmbarque.Text, Embarque)
                If oExisteEmbarque.Identificador > 0 Then
                    Dim Mensajes As New PortatilClasses.Mensaje(73)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActiveControl = txtNumeroEmbarque
                    txtNumeroEmbarque.SelectAll()
                End If
            End If
            'Else
            If GLOBAL_BasculaInstalada = "1" And Me.Operacion = "Agregar" Then
                Dim oExisteEmbarque As New PortatilClasses.Consulta.cExisteEmbarque(1)
                oExisteEmbarque.CargarDatos(cboAlmacen.Identificador, txtPG.Text, txtNumeroEmbarque.Text, Embarque)
                If oExisteEmbarque.Identificador > 0 Then
                    'If oExisteEmbarque.Status <> "ABIERTO" And oExisteEmbarque.MovimientoAlmacen = 0 Then ' 20060724CAGP$001
                    If oExisteEmbarque.MovimientoAlmacen = 0 Then
                        Embarque = oExisteEmbarque.Identificador
                        If GLOBAL_PesoEmbarqueBasculaEmpresa = "1" Then ' 20060719CAGP$002
                            txtTicket.Text = CType(oExisteEmbarque.Folio, String)
                            txtPesoLleno.Text = CType(oExisteEmbarque.PesoTaraLleno, String)
                            txtPesoVacio.Text = CType(oExisteEmbarque.PesoTaraVacio, String)
                        End If

                        txtCapacidadPG.Text = CType(oExisteEmbarque.Capacidad, String)
                        'dtpFMovimiento.Value = oExisteEmbarque.FRecepcion

                        dtpFEmbarque.MaxDate = dtpFMovimiento.Value
                        dtpFEmbarque.MinDate = oExisteEmbarque.FEmbarque
                        dtpFEmbarque.Value = oExisteEmbarque.FEmbarque
                        dtpFRecepcion.MinDate = dtpFEmbarque.Value
                        dtpFRecepcion.MaxDate = dtpFMovimiento.Value
                        dtpHInicio.MinDate = dtpFMovimiento.Value.AddMilliseconds(-1)
                        dtpHInicio.MaxDate = dtpFMovimiento.Value

                        'If dtpFMovimiento.Value > dtpHInicio.MaxDate Then
                        '    dtpHInicio.MaxDate = dtpFMovimiento.Value
                        '    dtpHInicio.Value = dtpFMovimiento.Value
                        '    dtpHInicio.MinDate = dtpFRecepcion.Value.AddMilliseconds(-1)
                        'Else
                        '    dtpHInicio.MinDate = dtpFRecepcion.Value.AddMilliseconds(-1)
                        '    dtpHInicio.Value = dtpFMovimiento.Value
                        '    dtpHInicio.MaxDate = dtpFMovimiento.Value
                        'End If
                        'dtpHFinal.MinDate = dtpHInicio.Value

                        'dtpFRecepcion.Value = oExisteEmbarque.FRecepcion
                        txtLitrosPemex.Text = oExisteEmbarque.LitrosPemex
                        txtKilosPemex.Text = oExisteEmbarque.KilosPemex
                        txtOperador.Text = oExisteEmbarque.NombreChofer
                        ' 20060505CAGP$002 /F
                    Else
                        If oExisteEmbarque.Status = "ABIERTO" Then
                            Dim Mensajes As New PortatilClasses.Mensaje(93)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            DatosSalvados = True
                            Me.Close()
                        End If
                        If oExisteEmbarque.MovimientoAlmacen > 0 Then
                            Dim Mensajes As New PortatilClasses.Mensaje(73)
                            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ActiveControl = txtNumeroEmbarque
                            txtNumeroEmbarque.SelectAll()
                        End If
                    End If
                Else
                    Embarque = 0
                    Dim Mensajes As New PortatilClasses.Mensaje(74)
                    MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ActiveControl = txtNumeroEmbarque   '20061107CAGP$001
                    txtNumeroEmbarque.SelectAll()       '20061107CAGP$001
                End If
            End If

        End If
    End Sub
    ' 20060719CAGP$002 /F

    ' Carga el producto del almacen destino
    Private Sub CargarProducto(ByVal AlmacenGas As Integer)
        If AlmacenGas > 0 Then
            Dim oProducto As New PortatilClasses.Consulta.cProductoContenedor(0, AlmacenGas)
            oProducto.CargaDatos()
            Producto = oProducto.Identificador
            oProducto = Nothing
        End If
    End Sub

    ' Checa si las existencia del almacen destino no rebasan el stock minimo que tiene asignado
    Private Function StockMinimo(ByVal AlmacenGas As Integer, ByVal Cantidad As Decimal) As Boolean
        Dim oAlmacenGasStock As New PortatilClasses.Catalogo.cAlmacenGasStock(1, AlmacenGas)
        Dim Litros As Decimal
        Litros = Cantidad / CType(FactorDensidad, Decimal)
        If oAlmacenGasStock.drReader.Read() Then
            If Litros > CType(oAlmacenGasStock.drReader(1), Decimal) Then
                oAlmacenGasStock.drReader.Close()
                oAlmacenGasStock.CerrarConexion()
                Return False
            End If
        Else
            oAlmacenGasStock.drReader.Close()
            oAlmacenGasStock.CerrarConexion()
            Return False
        End If
        oAlmacenGasStock.drReader.Close()
        oAlmacenGasStock.CerrarConexion()
        Return True
    End Function

    ' Registra el producto en la tabla de MovimientoAlmacenproducto
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer)
        Dim Kilos As Decimal
        Kilos = CType(txtKilosPemex.Text, Decimal)
        Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
        oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(3, Almacen, Producto, _
                                        MovimientoAlmacen, Kilos, Kilos, 1)
        oMovimientoAProducto.CargaDatos()
    End Sub

    ' Registra la iformacion del embarque
    Private Sub RegistrarEmbarque(ByVal MovimientoAlmacenE As Integer, ByVal AlmacenGas As Integer, _
    ByVal LitrosPemex As Decimal, ByVal FRecepcion As DateTime)
        Dim oEmbarque As PortatilClasses.Consulta.cEmbarque
        If GLOBAL_BasculaInstalada = "1" And Embarque > 0 Then
            ' Si el embarque fue pesado solo se modifican los datos del embarque y se actualizan las
            'existencias
            oEmbarque = New PortatilClasses.Consulta.cEmbarque(3)
        Else
            ' Si no existe bascula, se registra el embarque
            oEmbarque = New PortatilClasses.Consulta.cEmbarque(0)
            Embarque = 0
        End If
        Dim PesoLleno As Integer
        Dim PesoVacio As Integer
        Dim TotInicial As Decimal
        Dim TotFinal As Decimal

        If txtPesoLleno.Text = "" Then
            PesoLleno = Nothing
        Else
            PesoLleno = CType(txtPesoLleno.Text, Integer)
        End If
        If txtPesoVacio.Text = "" Then
            PesoVacio = Nothing
        Else
            PesoVacio = CType(txtPesoVacio.Text, Integer)
        End If
        If txtTotalizadorIMs.Text = "" Then
            TotInicial = Nothing
        Else
            TotInicial = CType(txtTotalizadorIMs.Text, Decimal)
        End If
        If txtTotalizadorFMs.Text = "" Then
            TotFinal = Nothing
        Else
            TotFinal = CType(txtTotalizadorFMs.Text, Decimal)
        End If

        oEmbarque.Registrar(Embarque, txtNumeroEmbarque.Text, CType(txtLitros100.Text, Decimal), LitrosPemex, _
        CType(txtKilosPemex.Text, Decimal), CType(txtPorcentaje.Text, Integer), dtpFEmbarque.Value, FRecepcion, 0, 0, _
        txtTicket.Text, txtOperador.Text, cboCorporativoFacturar.Identificador, PesoLleno, PesoVacio, _
        cboTransportadora.Identificador, Producto, cboOrigen.Identificador, MovimientoAlmacenE, _
        txtPG.Text, txtPlacas.Text, dtpHInicio.Value, dtpHFinal.Value, AlmacenGas, cboCelula.Identificador, TotInicial, _
        TotFinal, txtGarza.Text, GLOBAL_Usuario, cboProveedorGas.Identificador)

        '20161226$LUSATE Función para guardar imagenes de guías en la BD
        If oEmbarque.Identificador <> 0 And oEmbarque.Identificador <> Nothing Then
            If Not _lstGuiaEmbarques Is Nothing Then
                GuardarArchivosGuias(oEmbarque.Identificador)
            End If
        End If
        '20161226$LUSATE

        oEmbarque = Nothing
    End Sub

    ' Modifica la iformacion del embarque
    Private Sub ModificarEmbarque(ByVal FRecepcion As Date)
        Dim oEmbarque As New PortatilClasses.Consulta.cEmbarque(2)

        Dim PesoLleno As Integer
        Dim PesoVacio As Integer
        Dim TotInicial As Decimal
        Dim TotFinal As Decimal

        If txtPesoLleno.Text = "" Then
            PesoLleno = Nothing
        Else
            PesoLleno = CType(txtPesoLleno.Text, Integer)
        End If
        If txtPesoVacio.Text = "" Then
            PesoVacio = Nothing
        Else
            PesoVacio = CType(txtPesoVacio.Text, Integer)
        End If
        If txtTotalizadorIMs.Text = "" Then
            TotInicial = Nothing
        Else
            TotInicial = CType(txtTotalizadorIMs.Text, Decimal)
        End If
        If txtTotalizadorFMs.Text = "" Then
            TotFinal = Nothing
        Else
            TotFinal = CType(txtTotalizadorFMs.Text, Decimal)
        End If

        oEmbarque.Registrar(Embarque, txtNumeroEmbarque.Text, CType(txtLitros100.Text, Decimal), _
        CType(txtLitrosPemex.Text, Decimal), 0, CType(txtPorcentaje.Text, Integer), dtpFEmbarque.Value.Date, FRecepcion, 0, 0, _
        txtTicket.Text, txtOperador.Text, cboCorporativoFacturar.Identificador, PesoLleno, PesoVacio, _
        cboTransportadora.Identificador, Producto, cboOrigen.Identificador, 0, txtPG.Text, txtPlacas.Text, _
        dtpHInicio.Value, dtpHFinal.Value, 0, cboCelula.Identificador, TotInicial, TotFinal, txtGarza.Text, GLOBAL_Usuario, cboProveedorGas.Identificador)



        '20161226$LUSATE Función para guardar imagenes de guías en la BD       
        If oEmbarque.Identificador <> 0 And oEmbarque.Identificador <> Nothing Then
            If Not _lstGuiaEmbarques Is Nothing Then
                GuardarArchivosGuias(oEmbarque.Identificador)
            End If
        End If
        '20161226$LUSATE

        oEmbarque = Nothing
    End Sub

    ' Realiza los movimientos del embarque
    Private Sub RealizarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, "Embarques", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            RegistrarPG()
            CalcularTipoMovimiento()

            Dim Litros As Decimal
            Dim Kilos As Decimal
            Dim FechaMov As DateTime

            FechaMov = dtpFMovimiento.Value

            Kilos = CType(txtKilosPemex.Text, Decimal)
            Litros = Kilos / CType(FactorDensidad, Decimal)

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, cboAlmacen.Identificador, 0, TipoMovimiento, 0)

            Dim oMovimientoAlmacenE As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, cboAlmacen.Identificador, _
                                           FechaMov, Kilos, Litros, TipoMovimiento, dtpFRecepcion.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()
            RegistraMovimientoProducto(cboAlmacen.Identificador, oMovimientoAlmacenE.Identificador)

            RegistrarEmbarque(oMovimientoAlmacenE.Identificador, cboAlmacen.Identificador, CType(txtLitrosPemex.Text, Decimal), _
                              dtpFRecepcion.Value)

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenE.Identificador)
            End If

            'Llama al metodo de la medicion fisica para almacenar "CODIGO PAGO"
            If GLOBAL_MedicionFisica Then
                frmCaptura.AlmacenarInformacion(oMovimientoAlmacenE.Identificador, "MOVIMIENTO")
            End If

            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing

            Limpiar()
            DatosSalvados = True
            Close()
        End If
    End Sub

    ' Verfica la información para poder modificarla
    Private Sub ModificarMovimientos()
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Refresh()
            RegistrarPG()
            ModificarEmbarque(dtpFRecepcion.Value.Date)
            Limpiar()
            Embarque = 0
            DatosSalvados = True
            Close()
        End If
    End Sub

    ' Verifica la información para poder registrar el embarque
    Private Sub ValidarMovimientos()
        If StockMinimo(cboAlmacen.Identificador, CType(txtKilosPemex.Text, Decimal)) Then
            'Llama a la funcion de Medicion fisica y verifica que la informacion haya sido
            'correcta "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                If MedicionFisica() Then
                    RealizarMovimientos()
                End If
            Else
                RealizarMovimientos()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(5)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function FechaActual() As DateTime
        Dim Fecha As DateTime
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(1, cboAlmacen.Identificador)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), DateTime)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub InicializarFechas()
        dtpFMovimiento.Value = FechaActual()
        dtpFMovimiento.MinDate = FechaActual.AddDays(-GLOBAL_MaxDiasMovEmbarque)
        dtpFMovimiento.MaxDate = FechaActual()
        dtpFRecepcion.Value = dtpFMovimiento.Value
        dtpHInicio.Value = dtpFMovimiento.Value
        dtpHFinal.Value = dtpFMovimiento.Value
        dtpFEmbarque.Value = dtpFMovimiento.Value


        dtpFEmbarque.MaxDate = dtpFMovimiento.Value
        dtpFEmbarque.MinDate = dtpFMovimiento.Value.Date.AddDays(-GLOBAL_MaxDiasMovEmbarque)
        dtpFRecepcion.MinDate = dtpFEmbarque.Value
        dtpFRecepcion.MaxDate = dtpFMovimiento.Value
        dtpHInicio.MinDate = dtpFMovimiento.Value
        dtpHInicio.MaxDate = dtpFMovimiento.Value
        dtpHFinal.MinDate = dtpFMovimiento.Value
        dtpHFinal.MaxDate = dtpHFinal.Value.AddHours(24)
    End Sub

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        'dtpFMovimiento.Value = FechaActual()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value

            dtpFRecepcion.MaxDate = dtpFMovimiento.Value

        End If
        dtpFRecepcion.Value = dtpFMovimiento.Value
        dtpHInicio.Value = dtpFMovimiento.Value
        dtpHFinal.Value = dtpFMovimiento.Value
        dtpFEmbarque.Value = dtpFMovimiento.Value

        dtpFEmbarque.MaxDate = dtpFMovimiento.Value
    End Sub

    ' Habilita o Deshabilita los controles que no se pueden modificar
    Private Sub HabilitarControles(ByVal Habilitar As Boolean)
        cboCorporativoDestino.Enabled = Habilitar
        cboCorporativoFacturar.Enabled = Habilitar  ' 20060815CAGP$002
        cboAlmacen.Enabled = Habilitar
        dtpFMovimiento.Enabled = Habilitar
        txtKilosPemex.ReadOnly = Not Habilitar
    End Sub

    Private Sub CalcularCapacidadal90()
        If txtLitrosPemex.Text = "" And txtCapacidadPG.Text <> "" Then
            Dim Capacidad90 As Double
            Capacidad90 = CType(txtCapacidadPG.Text, Decimal) * 0.9
            txtLitrosPemex.Text = CType(Capacidad90, String)
        End If
        If txtLitros100.Text = "" And txtCapacidadPG.Text <> "" Then
            txtLitros100.Text = txtCapacidadPG.Text
        End If
    End Sub

    ' Carga los datos del embarque a los controles correspondientes
    Private Sub CargarDatos(ByVal Embarque As Integer)
        Dim oEmbarque As New PortatilClasses.Consulta.cEmbarque(1)
        oEmbarque.Consultar(Embarque)
        If oEmbarque.drAlmacen.Read() Then
            cboCorporativoFacturar.PosicionaCombo(CType(oEmbarque.drAlmacen(0), Integer))
            cboCorporativoDestino.PosicionaCombo(CType(oEmbarque.drAlmacen(1), Integer))
            cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoFacturar.Identificador, Short), 0, 0)
            cboAlmacen.PosicionaCombo(CType(oEmbarque.drAlmacen(2), Integer))

            Try
                ' 20060505CAGP$002 /I
                txtPesoLleno.Text = CType(oEmbarque.drAlmacen(19), String)
                txtPesoVacio.Text = CType(oEmbarque.drAlmacen(20), String)
                txtPG.Text = CType(oEmbarque.drAlmacen(9), String)
                dtpFMovimiento.Value = CType(oEmbarque.drAlmacen(4), DateTime)
                If dtpFMovimiento.Value > dtpHInicio.MaxDate Then
                    dtpHInicio.MaxDate = dtpFMovimiento.Value
                    dtpHInicio.Value = dtpFMovimiento.Value
                    dtpHInicio.MinDate = dtpFMovimiento.Value.AddMilliseconds(-1)
                Else
                    dtpHInicio.MinDate = dtpFMovimiento.Value.AddMilliseconds(-1)
                    dtpHInicio.Value = dtpFMovimiento.Value
                    dtpHInicio.MaxDate = dtpFMovimiento.Value
                End If
                dtpFEmbarque.Value = CType(oEmbarque.drAlmacen(5), DateTime)
                dtpFRecepcion.MinDate = CType(CType(dtpFEmbarque.Value.Date, String) & " 00:00:00", DateTime)
                dtpFRecepcion.MaxDate = dtpFMovimiento.Value
                dtpFRecepcion.Value = CType(oEmbarque.drAlmacen(6), DateTime)


                txtNumeroEmbarque.Text = CType(oEmbarque.drAlmacen(3), String)
                cboTransportadora.PosicionaCombo(CType(oEmbarque.drAlmacen(7), Integer))
                cboOrigen.PosicionaCombo(CType(oEmbarque.drAlmacen(8), Integer))
                txtPlacas.Text = CType(oEmbarque.drAlmacen(10), String)
                txtOperador.Text = CType(oEmbarque.drAlmacen(11), String)
                txtLitros100.Text = CType(oEmbarque.drAlmacen(12), String)
                txtLitrosPemex.Text = CType(oEmbarque.drAlmacen(13), String)
                txtKilosPemex.Text = CType(oEmbarque.drAlmacen(14), String)
                txtPorcentaje.Text = CType(oEmbarque.drAlmacen(15), String)
                dtpHInicio.Value = CType(oEmbarque.drAlmacen(16), DateTime)
                dtpHFinal.MinDate = dtpHInicio.Value
                dtpHFinal.Value = CType(oEmbarque.drAlmacen(17), DateTime)

                txtTicket.Text = CType(oEmbarque.drAlmacen(18), String)
                If Not IsDBNull(oEmbarque.drAlmacen(23)) Then
                    If CType(oEmbarque.drAlmacen(23), Short) > 0 Then
                        cboCelula.PosicionaCombo(CType(oEmbarque.drAlmacen(23), Short))
                    End If
                End If
                txtTotalizadorIMs.Text = CType(oEmbarque.drAlmacen(21), String)
                txtTotalizadorFMs.Text = CType(oEmbarque.drAlmacen(22), String)

                Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(3, 0, txtPG.Text, "", 0, 0, _
                             CType(cboTransportadora.Identificador, Short))
                oTanque.VerificarCapacidad()
                If oTanque.NumeroTanque <> "" Then
                    txtCapacidadPG.Text = CType(oTanque.Capacidad, String)
                End If
                If Not IsDBNull(oEmbarque.drAlmacen(24)) Then
                    txtGarza.Text = CType(oEmbarque.drAlmacen(24), String)
                End If
                ' 20060505CAGP$002 /F

                '20161226#LUSATE
                If CType(oEmbarque.drAlmacen("IdProveedorGas"), Integer) <> 0 Then
                    cboProveedorGas.SelectedValue = CType(oEmbarque.drAlmacen("IdProveedorGas"), Integer)
                Else
                    cboProveedorGas.SelectedValue = GLOBAL_ProveedorGasPorDefecto
                End If

            Catch
                cboTransportadora.PosicionarInicio()
                cboOrigen.PosicionarInicio()
            End Try
        End If
        oEmbarque.drAlmacen.Close()
        oEmbarque.CerrarConexion()
        oEmbarque = Nothing
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter y las fechas de arriba y abajo
    Private Sub txtNumeroEmbarque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtNumeroEmbarque.KeyDown, txtPlacas.KeyDown, txtPorcentaje.KeyDown, txtTicket.KeyDown, _
    txtPesoLleno.KeyDown, txtPesoVacio.KeyDown, txtTotalizadorFMs.KeyDown, txtTotalizadorIMs.KeyDown, _
    txtCapacidadPG.KeyDown, txtPG.KeyDown, txtOperador.KeyDown, txtLitros100.KeyDown, txtLitrosPemex.KeyDown, _
    txtKilosPemex.KeyDown, txtGarza.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    ' Inicialización de la forma
    Private Sub frmEmbarque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Limpiar()
        InicializarFechas()
        cboCorporativoFacturar.CargaDatos(0)

        cboCorporativoDestino.CargaDatos(0)
        cboCorporativoDestino.PosicionaCombo(GLOBAL_Empresa)

        cboCorporativoFacturar.PosicionaCombo(GLOBAL_Empresa)
        ''cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoFacturar.Identificador, GLOBAL_Usuario)
        ' 20060515CAGP$001 /I
        If cboCorporativoDestino.Text <> "" Then
            If GLOBAL_VerTodosAlmacenes Then
                If GLOBAL_EmbarqueEstacionario Or Operacion = "Modificar" Then
                    cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
                Else
                    cboAlmacen.CargaDatos(4, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
                End If
            Else
                If GLOBAL_EmbarqueEstacionario Or Operacion = "Modificar" Then
                    cboAlmacen.CargaDatos(14, GLOBAL_Usuario, GLOBAL_Celula)
                Else
                    cboAlmacen.CargaDatos(13, GLOBAL_Usuario, GLOBAL_Celula)
                End If
            End If
            CargarProducto(cboAlmacen.Identificador)
        End If        

        ' 20060515CAGP$001 /F
        If cboCorporativoFacturar.Text <> "" Then
            'cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoFacturar.Identificador, GLOBAL_Usuario)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoFacturar.Identificador, Short), 0, 0)
            HabilitarCelula()
        End If
        cboTransportadora.CargaDatosBase("spPTLCargaComboTransportadora", 0, GLOBAL_Usuario)
        cboOrigen.CargaDatosBase("spPTLCargaComboDestinoTransporte", 0, GLOBAL_Usuario)
        cboProveedorGas.CargaDatosBase("spLecturaProveedorGas", 0, GLOBAL_Usuario)        

        TabControl1.SelectedIndex = 0
        If Operacion = "Modificar" Then
            CargarDatos(Embarque)
            HabilitarControles(False)

            Dim oGuiaEmbarque As New GuardarArchivos.GuiaEmbarqueMetodos()
            oGuiaEmbarque.Conexion = GLOBAL_Conexion
            oGuiaEmbarque.Embarque = Embarque
            _lstGuiaEmbarques = oGuiaEmbarque.Lectura()
        Else
            ValidarRangoFechas()
            cboProveedorGas.SelectedValue = GLOBAL_ProveedorGasPorDefecto
        End If
        If cboCorporativoDestino.Enabled Then
            Me.ActiveControl = cboCorporativoDestino
        Else
            Me.ActiveControl = cboCorporativoFacturar
        End If
        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim
        Titulo = Me.Text
        PosicionaCombo()
        ' 20060515CAGP$001 /I
        If GLOBAL_VerTodosAlmacenes = False Then
            cboCorporativoDestino.Enabled = False
            ActiveControl = cboAlmacen
        End If
        ' 20060515CAGP$001 /F

        Cursor = Cursors.Default
    End Sub

    ' Evento del control cboCorporativoDestino, carga los almacenes d ela empresa seleccionada
    Private Sub cboCorporativoDestino_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativoDestino.SelectedIndexChanged
        If cboCorporativoDestino.Focused And cboCorporativoDestino.Text <> "" Then
            Cursor = Cursors.WaitCursor
            If GLOBAL_EmbarqueEstacionario Or Operacion = "Modificar" Then
                cboAlmacen.CargaDatos(9, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
            Else
                cboAlmacen.CargaDatos(4, GLOBAL_Usuario, cboCorporativoDestino.Identificador)
            End If

            If cboAlmacen.Identificador > 0 Then
                CargarProducto(cboAlmacen.Identificador)
            End If
            HabilitarAceptar()
            HabilitarCelula()
            Cursor = Cursors.Default
        End If
    End Sub

    ' Selecciona la siguiente pagina
    Private Sub btnSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        If TabControl1.SelectedIndex = TabControl1.TabCount - 1 Then
            TabControl1.SelectedIndex = 0
        Else
            TabControl1.SelectedIndex = TabControl1.SelectedIndex + 1
        End If
    End Sub

    ' Evento del control TabControl1 se activa cuando cambiamos de pagina
    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If TabControl1.Focus Then
            Select Case TabControl1.SelectedIndex
                Case 0
                    If cboCorporativoDestino.Enabled Then
                        Me.ActiveControl = cboCorporativoDestino
                    Else
                        Me.ActiveControl = cboCorporativoFacturar
                    End If
                Case 1
                    Me.ActiveControl = txtLitros100
            End Select
        End If
    End Sub

    ' Evento del control Cancelar, cierra la forma
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    ' Evento que se activa cuando hay algún cambio en los controles
    Private Sub cboCorporativoFacturar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtNumeroEmbarque.TextChanged
        HabilitarAceptar()
        'If txtNumeroEmbarque.Focused Then '20070123CAGP$001
        NumEnter = 1
        'End If
    End Sub

    ' Evento que se activa cuando hay algún cambio en los controles
    Private Sub cboOrigen_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cboOrigen.SelectedIndexChanged, txtPlacas.TextChanged, txtPorcentaje.TextChanged, _
    dtpHFinal.TextChanged, txtCapacidadPG.TextChanged, txtLitros100.TextChanged, _
    txtLitrosPemex.TextChanged, txtKilosPemex.TextChanged
        HabilitarAceptar()
    End Sub

    ' Evento del botón btnAceptar
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor

        If GLOBAL_RequiereArchivosGuia And ArchivoAdjuntoValido() = False Then
            Dim Mensajes As New PortatilClasses.Mensaje(148)
            MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cursor = Cursors.Default
            Exit Sub
        End If

        ' 20060617CAGP$002 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
        cboAlmacen.Identificador, 0) ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            If Operacion = "Agregar" Then
                ValidarMovimientos()
            End If
            If Operacion = "Modificar" Then
                ModificarMovimientos()
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
        ' 20060617CAGP$002 /F
        Cursor = Cursors.Default
    End Sub

    ' Evento del botón cboAlmacen, se activa cuando hay un cambio, carga el producto del Almacen Destino
    Private Sub cboAlmacen_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboAlmacen.SelectedIndexChanged
        If cboAlmacen.Focused Then
            Cursor = Cursors.WaitCursor
            HabilitarAceptar()
            CargarProducto(cboAlmacen.Identificador)
            HabilitarCelula()

            NumEnter = 1 ' 20070123CAGP$001
            Cursor = Cursors.Default
        End If
    End Sub



    ' Valida que la fecha de inicio sea menor o igual ala fecha de termino
    Private Sub dtpHInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpHInicio.TextChanged
        dtpHFinal.MinDate = dtpHInicio.Value
        HabilitarAceptar()
    End Sub

    ' Valida los controles txtLitros100 y txtLitrosPemex
    Private Sub txtLitros100_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtLitros100.Leave, txtLitrosPemex.Leave
        If txtLitros100.Text <> "" And txtLitrosPemex.Text <> "" Then
            If CType(txtLitros100.Text, Decimal) < CType(txtLitrosPemex.Text, Decimal) Then
                Dim Mensajes As New PortatilClasses.Mensaje(6)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = CType(sender, Control)
                CType(sender, Control).Select()
            End If
        End If
    End Sub

    ' Valida los controles txtPesoLleno y txtPesoVacio
    Private Sub txtPesoLleno_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtPesoLleno.Leave, txtPesoVacio.Leave
        If txtPesoLleno.Text <> "" And txtPesoVacio.Text <> "" Then
            If CType(txtPesoLleno.Text, Integer) < CType(txtPesoVacio.Text, Integer) Then
                Dim Mensajes As New PortatilClasses.Mensaje(8)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = CType(sender, Control)
                CType(sender, Control).Select()
            End If
        End If
    End Sub

    ' Valida los controles txtTotalizadorIMs y txtTotalizadorFMs
    Private Sub txtTotalizadorIMs_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles txtTotalizadorFMs.Leave, txtTotalizadorIMs.Leave
        If txtTotalizadorIMs.Text <> "" And txtTotalizadorFMs.Text <> "" Then
            If CType(txtTotalizadorIMs.Text, Decimal) > CType(txtTotalizadorFMs.Text, Decimal) Then
                Dim Mensajes As New PortatilClasses.Mensaje(9)
                MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Mensajes = Nothing
                ActiveControl = CType(sender, Control)
                CType(sender, Control).Select()
            End If
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub cboCorporativoFacturar_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles cboCorporativoFacturar.KeyDown, cboCorporativoDestino.KeyDown, cboAlmacen.KeyDown, dtpFEmbarque.KeyDown, _
    dtpFRecepcion.KeyDown, cboOrigen.KeyDown, dtpHInicio.KeyDown, dtpHFinal.KeyDown, _
    dtpFMovimiento.KeyDown, cboCelula.KeyDown, cboTransportadora.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub dtpFMovimiento_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
       Handles dtpFMovimiento.Leave
        dtpFEmbarque.MaxDate = dtpFMovimiento.Value
        dtpFEmbarque.MinDate = dtpFMovimiento.Value.Date.AddDays(-GLOBAL_MaxDiasMovEmbarque)
        dtpFRecepcion.MinDate = CType(CType(dtpFEmbarque.Value.Date, String) & " 00:00:00", DateTime)
        dtpFRecepcion.MaxDate = dtpFMovimiento.Value

        '#001 Inician Cambios
        If dtpFMovimiento.Value > dtpHInicio.MaxDate Then
            dtpHInicio.MaxDate = dtpFMovimiento.Value
            dtpHInicio.Value = dtpFMovimiento.Value
            dtpHInicio.MinDate = dtpFMovimiento.Value.AddMilliseconds(-1)
        Else
            dtpHInicio.MinDate = dtpFMovimiento.Value.AddMilliseconds(-1)
            dtpHInicio.Value = dtpFMovimiento.Value
            dtpHInicio.MaxDate = dtpFMovimiento.Value
        End If
        '#001 Terminan Cambios

        dtpHFinal.MinDate = dtpFMovimiento.Value
        dtpHFinal.MaxDate = dtpHFinal.Value.AddHours(24)

        dtpFMovimiento.Refresh()
        HabilitarAceptar()
    End Sub

    ' Valida que la fecha de embarque sea menor o igual a la fecha de recepcion
    Private Sub dtpFEmbarque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFEmbarque.Leave
        dtpFRecepcion.MinDate = CType(CType(dtpFEmbarque.Value.Date, String) & " 00:00:00", DateTime)
        dtpFRecepcion.MaxDate = dtpFMovimiento.Value
        HabilitarAceptar()
    End Sub

    Private Sub dtpFRecepcion_Enter(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles dtpFRecepcion.Enter, dtpFRecepcion.TextChanged
        If dtpFRecepcion.Focused Then
            MyBase.Refresh()
            dtpFRecepcion.MinDate = CType(CType(dtpFEmbarque.Value.Date, String) & " 00:00:00", DateTime)
            dtpFRecepcion.MaxDate = dtpFMovimiento.Value
            HabilitarAceptar()
        End If
    End Sub

    Private Sub dtpFRecepcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFRecepcion.KeyPress
        If dtpFRecepcion.Focused Then
            dtpFRecepcion.MinDate = CType(CType(dtpFEmbarque.Value.Date, String) & " 00:00:00", DateTime)
            dtpFRecepcion.MaxDate = dtpFMovimiento.Value
            HabilitarAceptar()
        End If
    End Sub

    Private Sub dtpFMovimiento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFMovimiento.KeyPress
        If dtpFMovimiento.Value > dtpFMovimiento.MaxDate Or dtpFMovimiento.Value < dtpFMovimiento.MinDate Then
            dtpFMovimiento.Value = dtpFMovimiento.MaxDate
            HabilitarAceptar()
        End If

    End Sub

    Private Sub dtpFMovimiento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFMovimiento.TextChanged
        If dtpFMovimiento.Focused Then
            If dtpFMovimiento.Value > dtpFMovimiento.MaxDate Or dtpFMovimiento.Value < dtpFMovimiento.MinDate Then
                dtpFMovimiento.Value = dtpFMovimiento.MaxDate
                HabilitarAceptar()
            End If
        End If
    End Sub

    Private Sub frmEmbarque_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
    Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub txtNumeroEmbarque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtNumeroEmbarque.Leave, cboAlmacen.Leave
        ExisteEmbarque(sender)
        NumEnter = 2 '20070123CAGP$001
    End Sub

    Private Sub cboCorporativoFacturar_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles cboCorporativoFacturar.SelectedIndexChanged, cboCorporativoDestino.SelectedIndexChanged
        HabilitarAceptar()
        If cboCorporativoFacturar.Focused Then
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", cboCorporativoFacturar.Identificador, GLOBAL_Usuario)
            cboCelula.CargaDatosBase("spPTLCargaComboCelula", 0, GLOBAL_Usuario, CType(cboCorporativoFacturar.Identificador, Short), 0, 0)
        End If
        HabilitarCelula()
    End Sub

    Private Sub txtPG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtPG.TextChanged, cboTransportadora.SelectedIndexChanged
        HabilitarAceptar()
        If txtPG.Focused Or cboTransportadora.Focused Then
            NumEnter = 1
        End If
    End Sub

    Private Sub txtPG_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPG.Leave, _
    cboTransportadora.Leave
        If txtPG.Focused Then
            ExisteEmbarque(sender)
        End If
        BuscarPG()
        NumEnter = 2 '20070123CAGP$001
    End Sub

    Private Sub txtCapacidadPG_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapacidadPG.Leave
        CalcularCapacidadal90()
    End Sub

    'Private Sub txtPG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPG.KeyPress
    '    If e.KeyChar.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or e.KeyChar.IsLetter(e.KeyChar) Then e.Handled = False Else e.Handled = True
    'End Sub

    Private Sub txtPG_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPG.Enter
        txtPG.SelectAll()
    End Sub

    Private Sub btnAdjuntarGuias_Click(sender As System.Object, e As System.EventArgs) Handles btnAdjuntarGuias.Click
        '20161226$LUSATE Función para guardar imagenes de guías en la BD
        Dim frmAdjuntarArchivos As New GuardarArchivos.frmVisualizador()      

        frmAdjuntarArchivos.Embarque = Embarque

        If Not _lstGuiaEmbarques Is Nothing Then
            frmAdjuntarArchivos.lstGuiaEmbarques = _lstGuiaEmbarques
        End If

        If frmAdjuntarArchivos.ShowDialog = Windows.Forms.DialogResult.OK Then
            _lstGuiaEmbarques = frmAdjuntarArchivos.lstGuiaEmbarques            
        End If

    End Sub

    Private Sub GuardarArchivosGuias(Embarque As Integer)
        '20161226$LUSATE Función para guardar imagenes de guías en la BD
        For Each GuiaEmbarque As GuiaEmbarqueMetodos In _lstGuiaEmbarques
            GuiaEmbarque.Conexion = GLOBAL_Conexion
            GuiaEmbarque.Embarque = Embarque
            GuiaEmbarque.Usuario = GLOBAL_Usuario


            If String.IsNullOrEmpty(GuiaEmbarque.RutaArchivo) = False Then
                GuiaEmbarque.Guardar()
            ElseIf GuiaEmbarque.BorrarEnBD Then
                GuiaEmbarque.Borrar()
            End If
        Next
    End Sub

    Private Function ArchivoAdjuntoValido() As Boolean
        Dim Resultado As Boolean
        Dim Archivo As GuiaEmbarqueMetodos

        Resultado = False

        For Each Archivo In _lstGuiaEmbarques
            If Archivo.BorrarEnBD = False Then
                Resultado = True
                Exit For
            End If
        Next

        Return Resultado
    End Function

End Class
