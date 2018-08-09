' Modifico: Claudia Aurora García Patiño
' Fecha: 17 de Junio del 2006
' Motivo: Se aumentaron unas lineas para validar que no este verificado el reporte FDIOP-01
' Identificador de cambios: 20060617CAGP$010

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 22/08/2006
'Motivo: Se aumento la condicion para que no se regsitre un movimeinto despues de que el reporte FDIOP-01
'haya sido verificado
'Identificador de cambios: 20060822CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 26/09/2006
'Motivo: Se habilito para que se registre la medicionfisica en la salida
'Identificador de cambios: 20060929CAGP$001

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmMovimientoResguardoSalida
    Inherits System.Windows.Forms.Form

    Private FactorDensidad As String
    Private DatosSalvados As Boolean
    Private NumEnter As Short
    Private Producto As Integer

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents dtpFReposicion As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgResguardos As System.Windows.Forms.DataGrid
    Friend WithEvents DataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMovimientoResguardoSalida))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgResguardos = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.DataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.DataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFReposicion = New System.Windows.Forms.DateTimePicker()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        CType(Me.dgResguardos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCliente
        '
        Me.txtCliente.AutoSize = False
        Me.txtCliente.Location = New System.Drawing.Point(130, 24)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 21)
        Me.txtCliente.TabIndex = 3
        Me.txtCliente.Text = ""
        Me.ToolTip1.SetToolTip(Me.txtCliente, "Ingrese el número de cliente")
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(508, 14)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 11
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.dgResguardos, Me.btnBuscar, Me.txtCliente, Me.lblRuta, Me.Label12, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblCliente, Me.Label3, Me.Label7, Me.dtpFReposicion})
        Me.grpDatos.Location = New System.Drawing.Point(12, 14)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(488, 410)
        Me.grpDatos.TabIndex = 13
        Me.grpDatos.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(16, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 14)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Resguardos"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgResguardos
        '
        Me.dgResguardos.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.dgResguardos.DataMember = ""
        Me.dgResguardos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.dgResguardos.Location = New System.Drawing.Point(8, 225)
        Me.dgResguardos.Name = "dgResguardos"
        Me.dgResguardos.ReadOnly = True
        Me.dgResguardos.Size = New System.Drawing.Size(472, 175)
        Me.dgResguardos.TabIndex = 62
        Me.dgResguardos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.AlternatingBackColor = System.Drawing.Color.Gainsboro
        Me.DataGridTableStyle1.DataGrid = Me.dgResguardos
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.DataGridTextBoxColumn1, Me.DataGridTextBoxColumn2, Me.DataGridTextBoxColumn3, Me.DataGridTextBoxColumn4, Me.DataGridTextBoxColumn5, Me.DataGridTextBoxColumn6, Me.DataGridTextBoxColumn7, Me.DataGridTextBoxColumn8, Me.DataGridTextBoxColumn9})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'DataGridTextBoxColumn1
        '
        Me.DataGridTextBoxColumn1.Format = "dd/MM/yyyy"
        Me.DataGridTextBoxColumn1.FormatInfo = Nothing
        Me.DataGridTextBoxColumn1.HeaderText = "Fecha "
        Me.DataGridTextBoxColumn1.MappingName = "FVenta"
        Me.DataGridTextBoxColumn1.Width = 65
        '
        'DataGridTextBoxColumn2
        '
        Me.DataGridTextBoxColumn2.Format = ""
        Me.DataGridTextBoxColumn2.FormatInfo = Nothing
        Me.DataGridTextBoxColumn2.HeaderText = "Folio"
        Me.DataGridTextBoxColumn2.MappingName = "NDocumento"
        Me.DataGridTextBoxColumn2.Width = 50
        '
        'DataGridTextBoxColumn3
        '
        Me.DataGridTextBoxColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn3.Format = "n2"
        Me.DataGridTextBoxColumn3.FormatInfo = Nothing
        Me.DataGridTextBoxColumn3.HeaderText = "Litros"
        Me.DataGridTextBoxColumn3.MappingName = "Litros"
        Me.DataGridTextBoxColumn3.Width = 75
        '
        'DataGridTextBoxColumn4
        '
        Me.DataGridTextBoxColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.DataGridTextBoxColumn4.Format = ""
        Me.DataGridTextBoxColumn4.FormatInfo = Nothing
        Me.DataGridTextBoxColumn4.HeaderText = "Camión"
        Me.DataGridTextBoxColumn4.MappingName = "Autotanque"
        Me.DataGridTextBoxColumn4.NullText = ""
        Me.DataGridTextBoxColumn4.Width = 50
        '
        'DataGridTextBoxColumn5
        '
        Me.DataGridTextBoxColumn5.Format = ""
        Me.DataGridTextBoxColumn5.FormatInfo = Nothing
        Me.DataGridTextBoxColumn5.HeaderText = "Almacén"
        Me.DataGridTextBoxColumn5.MappingName = "Descripcion"
        Me.DataGridTextBoxColumn5.Width = 115
        '
        'DataGridTextBoxColumn6
        '
        Me.DataGridTextBoxColumn6.Format = ""
        Me.DataGridTextBoxColumn6.FormatInfo = Nothing
        Me.DataGridTextBoxColumn6.HeaderText = "Num. Almacén"
        Me.DataGridTextBoxColumn6.MappingName = "AlmacenGas"
        Me.DataGridTextBoxColumn6.Width = 0
        '
        'DataGridTextBoxColumn7
        '
        Me.DataGridTextBoxColumn7.Format = ""
        Me.DataGridTextBoxColumn7.FormatInfo = Nothing
        Me.DataGridTextBoxColumn7.MappingName = "AñoAtt"
        Me.DataGridTextBoxColumn7.Width = 0
        '
        'DataGridTextBoxColumn8
        '
        Me.DataGridTextBoxColumn8.Format = ""
        Me.DataGridTextBoxColumn8.FormatInfo = Nothing
        Me.DataGridTextBoxColumn8.MappingName = "Folio"
        Me.DataGridTextBoxColumn8.Width = 0
        '
        'DataGridTextBoxColumn9
        '
        Me.DataGridTextBoxColumn9.Format = ""
        Me.DataGridTextBoxColumn9.FormatInfo = Nothing
        Me.DataGridTextBoxColumn9.MappingName = "MovimientoAlmacen"
        Me.DataGridTextBoxColumn9.Width = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(406, 28)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 61
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Location = New System.Drawing.Point(130, 80)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 28
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(16, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 14)
        Me.Label12.TabIndex = 24
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 14)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 14)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Location = New System.Drawing.Point(130, 108)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 4
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(130, 139)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 4
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Location = New System.Drawing.Point(130, 52)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 32
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 171)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 14)
        Me.Label7.TabIndex = 33
        Me.Label7.Text = "Fecha reposición:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFReposicion
        '
        Me.dtpFReposicion.CustomFormat = ""
        Me.dtpFReposicion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFReposicion.Location = New System.Drawing.Point(130, 167)
        Me.dtpFReposicion.Name = "dtpFReposicion"
        Me.dtpFReposicion.Size = New System.Drawing.Size(216, 21)
        Me.dtpFReposicion.TabIndex = 5
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(508, 46)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 12
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmMovimientoResguardoSalida
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(598, 438)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmMovimientoResguardoSalida"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Salida de gas por reposición"
        Me.grpDatos.ResumeLayout(False)
        CType(Me.dgResguardos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Crea la forma de Captura de medicon estacionario "CODIGO PACO"
    Dim frmCapturaMedicionEstacionario As New MedicionFisica.frmMedicionInicialFinalEst()
    Dim frmCapturaMedicionTanque As New MedicionFisica.frmMedicionTanqueAlmacen()

    'Funcion para validar que se haga la medicion fisica "CODIGO PACO"
    Private Sub MedicionFisicaPortatil(ByVal MovimientoAlmacen As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(0, MovimientoAlmacen, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(0, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    'Funcion que registra la medicion fisica de los almacenes tanque de almacenamiento
    Private Sub MedicionFisicaTanque(ByVal MovimientoSalida As Integer)
        Dim oMedicion As New PortatilClasses.CatalogosPortatil.cMedicionFisicaAutomProducto(2, MovimientoSalida, 0, 0, 0, 0, 0, GLOBAL_Usuario, GLOBAL_IDEmpleado, Now, "", "MOVIMIENTO")
        oMedicion.RegistrarModificarEliminar()

        Dim oMedicionFisicaCorte As New PortatilClasses.Consulta.cMedicionFisicaCorte(1, oMedicion.MedicionFisica)
        oMedicionFisicaCorte.RealizarMedicionFisicaCorte()
    End Sub

    'Funcion que destruye la forma de Captura de medicion fisica "CODIGO PACO"
    Private Sub DestruyeMedicionFisicaEstacionario()
        frmCapturaMedicionEstacionario = Nothing
        frmCapturaMedicionEstacionario = New MedicionFisica.frmMedicionInicialFinalEst()
        frmCapturaMedicionTanque = Nothing
        frmCapturaMedicionTanque = New MedicionFisica.frmMedicionTanqueAlmacen()
    End Sub

    '20060929CAGP$001
    'Funcion de Medicion Fisica para verificar que se haga "CODIGO PACO"
    Function MedicionFisica(ByVal Almacen As Integer) As Boolean
        Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, Almacen, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
        oAlmacenDestino.CargarAlmacenGas()

        If oAlmacenDestino.TipoAlmacengas = 4 Then
            Dim oTanque As New PortatilClasses.CatalogosPortatil.cTanqueFisico(4, 0, "", "", 0, Almacen, 0)
            oTanque.VerificarCapacidad()
            frmCapturaMedicionEstacionario.Text = "Lecturas físicas de gas por movimiento - [" + oAlmacenDestino.Descripcion + "]"
            frmCapturaMedicionEstacionario.InicializaForma(0, False, oTanque.NumeroTanque, oTanque.Tanque, CType(oTanque.Capacidad, Integer), 0, Almacen, GLOBAL_Usuario, GLOBAL_IDEmpleado, dtpFMovimiento.Value, CType(dtpFMovimiento.Value, String)) ' 20051229CAGP$003
            If frmCapturaMedicionEstacionario.ShowDialog = DialogResult.OK Then
                Return True
            Else
                DestruyeMedicionFisicaEstacionario()
                Return False
            End If
        ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
            Return True
        ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
            Return True
        ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
            Return True
        Else
            Return False
        End If
    End Function

    ' 20060929CAGP$001
    'Funcion de almacenar la medicion fisica "CODIGO PACO"
    Private Sub AlmacenarMedicionFisica(ByVal MovEntrada As Integer, ByVal AlmDestino As Integer)
        Dim oAlmacenDestino As New PortatilClasses.CatalogosPortatil.cAlmacenGas(1, AlmDestino, "", Now, "", 0, 0, 0, 0, 0, 0, "", 0, 0)
        oAlmacenDestino.CargarAlmacenGas()
        If oAlmacenDestino.TipoAlmacengas = 4 Then
            frmCapturaMedicionEstacionario.AlmacenarInformacion(MovEntrada, AlmDestino, "MOVIMIENTO")
            DestruyeMedicionFisicaEstacionario()
        ElseIf oAlmacenDestino.TipoAlmacengas = 1 Then
            MedicionFisicaTanque(MovEntrada)
        ElseIf oAlmacenDestino.TipoAlmacengas = 2 Then
            MedicionFisicaPortatil(MovEntrada)
        ElseIf oAlmacenDestino.TipoAlmacengas = 3 Then
            MedicionFisicaPortatil(MovEntrada)
        End If
    End Sub

    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub Limpiar()
        lblRuta.Text = ""
        lblEmpresa.Text = ""
        txtCliente.Clear()
        lblCliente.Text = ""
    End Sub

    ' Carga los datos de los resguardos realizados al cliente
    Private Sub CargarResguardos(ByVal Cliente As Integer)
        dgResguardos.DataSource = Nothing
        Dim oResguardos As New PortatilClasses.Consulta.cConsultaResguardos(0, Cliente)
        oResguardos.CargaDatos()
        dgResguardos.DataSource = oResguardos.dtTable
        oResguardos = Nothing
        HabilitarAceptar()
    End Sub

    ' Checa si los controles necesarios son llenados para habilitar el botón de Aceptar
    Private Sub HabilitarAceptar()
        If txtCliente.Text <> "" And lblCliente.Text <> "" And dgResguardos.VisibleRowCount > 0 Then
            btnAceptar.Enabled = True
        Else
            btnAceptar.Enabled = False
        End If
    End Sub

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Function ValidarRangoFechaVenta() As Date
        Dim Fecha As Date
        Dim oConsultaFechas As New PortatilClasses.Catalogo.ConsultaFechas(0, 0)
        If oConsultaFechas.drReader.Read() Then
            Fecha = CType(oConsultaFechas.drReader(0), Date)
        End If
        oConsultaFechas.CerrarConexion()
        oConsultaFechas = Nothing
        Return Fecha
    End Function

    ' Valida que las fecha mostradas esten validas dependiendo de los privilegios del usuario
    Private Sub ValidarRangoFechas()
        dtpFMovimiento.Value = ValidarRangoFechaVenta()
        If GLOBAL_ModificaFecha = False Then
            dtpFMovimiento.MinDate = dtpFMovimiento.Value.Date
            dtpFMovimiento.MaxDate = dtpFMovimiento.Value.Date
        End If
    End Sub

    ' Carga el producto del almacén, debido a que la carga se realiza directamente del contenedor
    Private Sub ProductoContenedor(ByVal Almacen As Integer)
        Cursor = Cursors.WaitCursor
        Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, Almacen)
        oProductoContenedor.CargaDatos()
        Producto = oProductoContenedor.Identificador
        oProductoContenedor = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Cursor = Cursors.WaitCursor
        Dim oCliente As New PortatilClasses.Consulta.cCliente(0, CType(txtCliente.Text, Integer), 0)

        Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
        Dim strURLGateway As String = CType(oConfig.Parametros("URLGateway"), String).Trim

        If strURLGateway = "" Then
            oCliente.CargaDatos()
        Else
            oCliente.CargaDatos(strURLGateway, CByte(GLOBAL_Modulo))
        End If

        dgResguardos.DataSource = Nothing
        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo
            CargarResguardos(CType(txtCliente.Text, Integer))
        Else
            Limpiar()
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, "Modulo  de carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
            txtCliente.Clear()
        End If
        oCliente = Nothing
        Cursor = Cursors.Default
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
            rptReporte.Load(GLOBAL_RutaReportes & "\ReporteTicketResguardo.rpt")

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

    ' Registra el producto en la tabla de MovimientoAlmacenproducto
    Private Sub RegistraMovimientoProducto(ByVal Almacen As Integer, ByVal MovimientoAlmacen As Integer, _
    ByVal Litros As Decimal, ByVal Kilos As Decimal)

        Dim oMovimientoAProducto As PortatilClasses.Consulta.cMovimientoAProducto
        oMovimientoAProducto = New PortatilClasses.Consulta.cMovimientoAProducto(1, Almacen, Producto, _
                                        MovimientoAlmacen, Kilos, Litros, 1)
        oMovimientoAProducto.CargaDatos()
    End Sub

    ' Realiza los movimientos del trasiego
    Private Sub RealizarMovimientos(ByVal Almacen As Integer, ByVal Litros As Decimal, _
    ByVal MovimientoAlmacen As Integer)
        Dim Result As DialogResult
        Dim Mensajes As New PortatilClasses.Mensaje(4)
        Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If Result = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Refresh()
            Dim Kilos As Decimal
            Dim FechaMov As DateTime
            Dim oConfig As New SigaMetClasses.cConfig(GLOBAL_Modulo, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
            Dim FactorDensidad As String
            FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim

            FechaMov = dtpFMovimiento.Value

            Kilos = Litros * CType(FactorDensidad, Decimal)

            Dim Ano As Integer
            Dim Folio As Integer
            Ano = CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 6), Integer)
            Folio = CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 7), Integer)

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, Almacen, 0, 7, 0)

            Dim oMovimientoAlmacenS As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, Almacen, _
                                           FechaMov, Kilos, Litros, 7, dtpFReposicion.Value, oFolioMovimientoAlmacen.NDocumento, _
                                           oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                           oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenS.CargaDatos()
            RegistraMovimientoProducto(Almacen, oMovimientoAlmacenS.Identificador, Litros, Kilos)
            ' Registra la información en la tabla de AutoTanqueTurno
            Dim oAutotanqueTurno As New PortatilClasses.Consulta.cAutoTanqueTurno(1)
            oAutotanqueTurno.CargaDatos(Ano, 0, Now, Folio, 0, 1, 0, 1, 0, 0, 0, False)

            Dim oMovimientoEntreAlmacenes As New PortatilClasses.Consulta.cMovimientoEntreAlmacenes(0, Almacen, _
                                                 MovimientoAlmacen, Almacen, oMovimientoAlmacenS.Identificador)

            oMovimientoEntreAlmacenes.CargaDatos()

            ' 20060929CAGP$001
            'Llama a la funcion para almacenar la medicion fisica "CODIGO PACO"
            If GLOBAL_MedicionFisica Then
                AlmacenarMedicionFisica(oMovimientoAlmacenS.Identificador, Almacen)
            End If

            If GLOBAL_Imprimir = "1" Then
                ImprimirReporte(0, oMovimientoAlmacenS.Identificador)
            End If

            oMovimientoAlmacenS = Nothing
            oFolioMovimientoAlmacen = Nothing
            oAutotanqueTurno = Nothing
            oMovimientoEntreAlmacenes = Nothing
            DatosSalvados = True
            Limpiar()
            Cursor = Cursors.Default
            Close()
        End If
    End Sub

    ' Verfica si las existencia del almacén origen, si son suficientes para realizar el traspaso
    Private Function VerificarExistencias(ByVal Almacen As Integer, ByVal Cantidad As Decimal) As Boolean
        Dim VerificaExistencia As New PortatilClasses.Consulta.cExistencia(1, Almacen, Producto, _
                                      Cantidad)
        VerificaExistencia.CargaDatos()
        If VerificaExistencia.Existencia = 0 Then
            Return False
        End If
        Return True
    End Function

    ' 20060929CAGP$001
    ' Valida la factibilidad del movimiento
    Private Sub ValidarMovimientos()
        Dim Litros As Decimal
        Dim Almacen As Integer
        Dim MovimientoAlmacen As Integer
        Litros = CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 2), Decimal)
        Almacen = CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 5), Integer)
        MovimientoAlmacen = CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 8), Integer)
        ProductoContenedor(Almacen)
        If VerificarExistencias(Almacen, Litros) Then
            If GLOBAL_MedicionFisica Then
                If MedicionFisica(Almacen) Then
                    RealizarMovimientos(Almacen, Litros, MovimientoAlmacen)
                End If
            Else
                RealizarMovimientos(Almacen, Litros, MovimientoAlmacen)
            End If
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(1)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
        End If
    End Sub

    Private Sub frmMovimientoResguardoSalida_Load(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        btnAceptar.Enabled = False
        ActiveControl = txtCliente
        ValidarRangoFechas()
        Limpiar()

        DatosSalvados = False
        Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtCliente.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub frmMovimientoResguardoSalida_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If DatosSalvados = False Then
            Dim Result As DialogResult
            Dim Mensajes As New PortatilClasses.Mensaje(28)
            Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If Result = DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                BuscarCliente()
                ActiveControl = dtpFMovimiento
            Else
                ActiveControl = txtCliente
            End If
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCliente.TextChanged
        HabilitarAceptar()
        NumEnter = 1
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        If NumEnter = 1 And txtCliente.Text <> "" Then
            BuscarCliente()
            NumEnter = 2
        End If
    End Sub

    Private Sub dtpFMovimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles dtpFMovimiento.KeyDown, dtpFReposicion.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ' 20060617CAGP$010 /I
        Dim oMovimiento As New PortatilClasses.Consulta.cMovAprobadoyVerificado(dtpFMovimiento.Value, _
               CType(dgResguardos.Item(dgResguardos.CurrentRowIndex, 5), Integer), 0) ' 20060822CAGP$001
        If oMovimiento.RealizarMovimiento() Then
            ValidarMovimientos()
        Else
            Dim Mensajes As New PortatilClasses.Mensaje(87, oMovimiento.Mensaje)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
        End If
        oMovimiento = Nothing
        ' 20060617CAGP$010 /F
    End Sub
End Class
