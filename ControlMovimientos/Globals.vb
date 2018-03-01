'Modificó: Carlos Francisco Sánchez Lavariega
'Fecha: 26/11/2005
'Descripción: Se inicializaron las variables de 2 nuevas operaciones para las pantallas del programa compras(frmProgramaCompras) y ventas(frmProgramaVentas))
'Identificador de cambios: 20051125CFSL#002

'Modifico: Claudia Garcia
'fecha: 09/01/2006
'Motivo: Se agrego sucursal a la configuarcion 1
'Identificador de cambios: 20060109CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 18/01/2006
'Motivo: Se aumento la operacion 45 y un parametro para la impresión del ticket de traslado fisico
'Identificador de cambios: 20060118CAGP$002

'Modifico: Carlos Lavariega
'Fecha: 01/02/2006
'Motivo: Se modificó el acceso al módulo asi como parte de la lectura de parametros de la versión de Oaxaca
'Identificador de cambios: 20060201CFSL$001

'Modifico: Carlos Lavariega
'Fecha: 27/03/2006
'Motivo: Se modificó agrego el Actualizador automatico
'Identificador de cambios: 20060327CFSL#001

'Modifico: Carlos Lavariega
'Fecha: 27/03/2006
'Motivo: Se valido la carga de la imagen en la pantalla de login
'Identificador de cambios: 20060327CFSL#002


'Modifico: Claudia Aurora García Patiño
'Fecha: 20/02/2006
'Motivo: Se agrego una operacion
'Identificador de cambios: 20060220CAGP$001

'Modifico: Claudia Aurora García Patiño
'Fecha: 03/03/2006
'Motivo: Se agrego un parametro 
'Identificador de cambios: 20060303CAGP$001

'Modifico: Claudia Aurora García Patiño
'Fecha: 19/07/2006
'Motivo: Se agrego un parametro 
'Identificador de cambios: 20060719CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 06/07/2007
'Motivo: Se aumento un parametro para la validación de litros porcentaje y totalizador
'Identificador de cambios: 20070706CAGP$004

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 07/08/2008
'Motivo: Se aumento la operacion de agregar kilometraje de camiones portatil
'Identificador de cambios: 20080807CAGP$001

'Modifico: Claudia Aurora Garcia Patiño
'Fecha: 09/08/2011
'Motivo: Parametro que nos indica si se ligan los traslados con el peso bascula
'Identificador de cambios: 20110809CAGP$001

Imports System.Data.SqlClient

Module Globals

#Region "Variable Globales"
    'Variable Paco
    Public GLOBAL_MedicionFisica As Boolean
    Public GLOBAL_CajaUsuario As Byte
    Public GLOBAL_IDEmpleado As Integer
    Public GLOBAL_FactorDensidad As Decimal


    'Variables globales para toda la aplicacion
    Public GLOBAL_Servidor As String
    Public GLOBAL_BaseDatos As String
    Public GLOBAL_Usuario As String
    Public GLOBAL_UsuarioNombre As String
    Public GLOBAL_Celula As Byte
    Public GLOBAL_CelulaDescripcion As String 'Descripción de la célula
    Public GLOBAL_Password As String
    Public GLOBAL_Titulo As String
    Public GLOBAL_Modulo As Short
    Public GLOBAL_ConString As String
    Public GLOBAL_Conexion As SqlConnection
    Public GLOBAL_RutaReportes As String 'Carpeta en donde estan los reportes
    Public GLOBAL_VersionAutorizada As String 'La versión autorizada a ejecutar
    Public GLOBAL_MensajeVersion As String 'Mensaje que se presenta cuando se está ejecutando una versión desactualizada
    Public GLOBAL_BasculaInstalada As String 'Nos indica si al empresa tiene bascula en sus instalaciones
    Public GLOBAL_DetalleEmpresa As String 'Nos indica el número de empresa a detallar los traslados por Almacén
    Public GLOBAL_DetalleEmpresas As New ArrayList() 'Arreglo que nos indica el detalle de las empresas que requieren detalle de almacén
    Public GLOBAL_Ducto As String  'Indica si existe entrada por ducto
    Public GLOBAL_Imprimir As String 'Indica si los tickets de los movimeintos se van aimprimir
    Public GLOBAL_ModuloIntegrado As String 'Indica si el sistema esta integrado por otros modulos
    Public GLOBAL_PlantaUnica As String 'Indica si la empresa solo tiene una planta de almacenamiento
    Public GLOBAL_EmpresaComisionista As String  'Indica si la empresa es comisionista o no
    Public GLOBAL_MaxDiasMovEmbarque As Short 'Número de días de antigüedad que se hace movimiento de un embarque
    Public GLOBAL_ImprimirFisicoTraslado As String ' Indica si se va aimprimir el ticket del traslado ' 20060118CAGP$002
    Public GLOBAL_Sucursal As Short ' Indica a que sucursal pertene el usurio ' 20060109CAGP$001
    Public GLOBAL_IncrementaTotalizador As String  ' Indica si se incrementa el totalziador en los traslados '20060303CAGP$001
    Public GLOBAL_PesoEmbarqueBasculaEmpresa As String = "0"  ' Indica si el pesado del embarque es el mismo que el peso de la bascula de la empresa ' 20060719CAGP$001
    Public GLOBAL_PorcentajePermitido As Decimal = 30 'Porcentaje permitido para la diferencia en litros porcentaje y totalizador ' 20070706CAGP$004
    Public GLOBAL_FechaHoraCierre As String = "0"
    Public GLOBAL_TrasladosBascula As String = "0" '20110809CAGP$001
    Public GLOBAL_SeguridadReportes As Boolean = False '20160616#LUSATE
    Public GLOBAL_RequiereArchivosGuia As Boolean '20161226#LUSATE
    Public GLOBAL_ProveedorGasPorDefecto As Integer '20161226#LUSATE
    Public GLOBAL_ModificarControlRecipientesActaCierre As Boolean = False '20170228#LUSATE
    Public GLOBAL_AbrirActaCierre As Boolean = False '20170228#LUSATE


    Public GLOBAL_Empresa As Byte
    Public GLOBAL_ModificaFecha As Boolean = False 'Operacion 1
    Public GLOBAL_VerEmpresas As Boolean = False 'Operacion 2
    Public GLOBAl_Carga As Boolean = False 'Operacion 3
    Public GLOBAL_Traslado As Boolean = False 'Operacion 4
    Public GLOBAL_Embarque As Boolean = False 'Operacion 5
    Public GLOBAL_TrasladoCompleto As Boolean = False 'Operacion 6
    Public GLOBAL_CapEmbarque As Boolean = False 'Operacion 7
    Public GLOBAL_ModEmbarque As Boolean = False  'Operacion 8
    Public GLOBAL_EmbarqueEstacionario As Boolean = False ' Operacion 9
    Public GLOBAL_CancelarMov As Boolean = False '  Operacion 10
    Public GLOBAL_Reportes As Boolean = False  '  Operacion 11
    Public GLOBAL_Parametros As Boolean = False  '  Operacion 12
    Public GLOBAL_InventarioInicial As Boolean = False  '  Operacion 13  
    Public GLOBAl_ReposicionResguardo As Boolean = False ' Operacion 14
    Public GLOBAL_AutoCarburacion As Boolean = False ' Operacion 15
    Public GLOBAL_Consumo As Boolean = False ' Operacion 16
    Public GLOBAL_TrasladosCpraVta As Boolean = False ' Operacion 17
    Public GLOBAL_Ducto18 As Boolean = False ' Operacion 18
    Public GLOBAL_ModificarDucto As Boolean = False ' Operacion 19
    Public GLOBAl_AgregarDucto As Boolean = False ' Operacion 20
    Public GLOBAL_InventarioFisico As Boolean = False '  Operacion 21
    Public GLOBAL_VerificarReporte As Boolean = False '  Operacion 22
    Public GLOBAL_AprobarReporte As Boolean = False '  Operacion 23
    Public GLOBAL_ReporteFisico As Boolean = False '  Operacion 24
    Public GLOBAL_ReporteContable As Boolean = False '  Operacion 25
    Public GLOBAL_Cancelacion26 As Boolean = False ' Operacion 26
    Public GLOBAL_Cancelacion27 As Boolean = False ' Operacion 27
    Public GLOBAL_Cancelacion28 As Boolean = False ' Operacion 28
    Public GLOBAL_Cancelacion29 As Boolean = False ' Operacion 29
    Public GLOBAL_Cancelacion30 As Boolean = False ' Operacion 30
    Public GLOBAL_Cancelacion31 As Boolean = False ' Operacion 31
    Public GLOBAL_VerTodosAlmacenes As Boolean = False 'Operacion 32
    Public GLOBAL_ProgramaCompras As Boolean = False 'Operacion 33      '#002
    Public GLOBAL_ProgramaVentas As Boolean = False 'Operacion 34       '#002
    Public GLOBAL_TrasladosSinAlmacen As Boolean = False ' Operacion 45 ' 20060118CAGP$002
    Public GLOBAL_ImprimitTicketPlantas As Boolean = False ' Operacion 46  '20060220CAGP$001
    Public GLOBAL_VerCatalogos As Boolean = False
    Public GLOBAL_AgregarKm As Boolean = False ' Operacion 50 ' 20080807CAGP$001
    Public GLOBAL_CancelarKm As Boolean = False 'Operacion 51 ' 20080807CAGP$001
    Public GLOBAL_ConsultarKm As Boolean = False 'Operacion 52 ' 20080807CAGP$001
    Public GLOBAL_PreliquidacionPort As Boolean = False 'Operacion 54 ' 20111122CAGP$001
    Public GLOBAL_ComConfiguracion As Boolean = False 'Operacion 55 ' 20111122CAGP$001
    Public GLOBAL_ComDeduccionPrestacion As Boolean = False 'Operacion 56 ' 20111122CAGP$001
    Public GLOBAL_ComConsultarComisiones As Boolean = False 'Operacion 57 ' 20111122CAGP$001
    Public GLOBAL_ImportarVtas As Boolean = False 'Operacion 64
    Public GLOBAL_Trasiego As Boolean = False 'OPeracion 65
    Public GLOBAL_InventarioFisicoActaCierre As Boolean = False 'Operacion 66    
    Public GLOBAL_CancelacionTomaIActaCierre As Boolean = False 'Operacion 67
    Public GLOBAL_CancelacionControlRecipientesActaCierre As Boolean = False 'Operacion 68
    Public GLOBAL_AccesoReportesAtaCierre As Boolean = False 'Operacion 69
    Public GLOBAL_AltaActaCierre As Boolean = False 'Operacion 70
    Public GLOBAL_CierreActaCierre As Boolean = False 'Operacion 71
    Public GLOBAL_CancelacionActaCierre As Boolean = False 'Operacion 72




#End Region

#Region "Privilegios del Modulo"
    Private Function CargarPrvilegios() As Boolean
        Dim sqlQuery As New SqlClient.SqlCommand()
        Dim daAcceso As New SqlClient.SqlDataAdapter()
        Dim dtOperaciones As New DataTable()
        Dim Rw As DataRow
        daAcceso.SelectCommand = sqlQuery
        sqlQuery.CommandText = "exec spSEGOperacionesUsuarioModulo " & GLOBAL_Usuario & "," & CType(GLOBAL_Modulo, String)
        sqlQuery.Connection = GLOBAL_Conexion
        Try
            daAcceso.Fill(dtOperaciones)
            If dtOperaciones.Rows.Count = 0 Then
                MessageBox.Show("El usuario no tiene privilegios para usar este módulo", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sqlQuery.Connection.Close()
                Return False
            End If
            For Each Rw In dtOperaciones.Rows
                GLOBAL_Titulo = CType(Rw(3), String)
                Select Case CInt(Rw(0).ToString())
                    Case 1
                        GLOBAL_ModificaFecha = True
                    Case 2
                        GLOBAL_VerEmpresas = True
                    Case 3
                        GLOBAl_Carga = True
                    Case 4
                        GLOBAL_Traslado = True
                    Case 5
                        GLOBAL_Embarque = True
                    Case 6
                        GLOBAL_TrasladoCompleto = True
                    Case 7
                        GLOBAL_CapEmbarque = True
                    Case 8
                        GLOBAL_ModEmbarque = True
                    Case 9
                        GLOBAL_EmbarqueEstacionario = True
                    Case 10
                        GLOBAL_CancelarMov = True
                    Case 11
                        GLOBAL_Reportes = True
                    Case 12
                        GLOBAL_Parametros = True
                    Case 13
                        GLOBAL_InventarioInicial = True
                    Case 14
                        GLOBAl_ReposicionResguardo = True
                    Case 15
                        GLOBAL_AutoCarburacion = True
                    Case 16
                        GLOBAL_Consumo = True
                    Case 17
                        GLOBAL_TrasladosCpraVta = True
                    Case 18
                        GLOBAL_Ducto18 = True
                    Case 19
                        GLOBAL_ModificarDucto = True
                    Case 20
                        GLOBAl_AgregarDucto = True
                    Case 21
                        GLOBAL_InventarioFisico = True
                    Case 22
                        GLOBAL_VerificarReporte = True
                    Case 23
                        GLOBAL_AprobarReporte = True
                    Case 24
                        GLOBAL_ReporteFisico = True
                    Case 25
                        GLOBAL_ReporteContable = True
                    Case 26
                        GLOBAL_Cancelacion26 = True
                    Case 27
                        GLOBAL_Cancelacion27 = True
                    Case 28
                        GLOBAL_Cancelacion28 = True
                    Case 29
                        GLOBAL_Cancelacion29 = True
                    Case 30
                        GLOBAL_Cancelacion30 = True
                    Case 31
                        GLOBAL_Cancelacion31 = True
                    Case 32
                        GLOBAL_VerTodosAlmacenes = True
                    Case 33                                 '#002
                        GLOBAL_ProgramaCompras = True       '#002
                    Case 34                                 '#002
                        GLOBAL_ProgramaVentas = True        '#002
                    Case 45
                        GLOBAL_TrasladosSinAlmacen = True   '20060118CAGP$002
                    Case 46
                        GLOBAL_ImprimitTicketPlantas = True  '20060220CAGP$001
                    Case 49
                        GLOBAL_VerCatalogos = True
                    Case 50
                        GLOBAL_AgregarKm = True ' 20080807CAGP$001 
                    Case 51
                        GLOBAL_CancelarKm = True ' 20080807CAGP$001
                    Case 52
                        GLOBAL_ConsultarKm = True ' 20080807CAGP$001
                    Case 54
                        GLOBAL_PreliquidacionPort = True '20111122CAGP$001
                    Case 55
                        GLOBAL_ComConfiguracion = True '20111122CAGP$001
                    Case 56
                        GLOBAL_ComDeduccionPrestacion = True '20111122CAGP$001
                    Case 57
                        GLOBAL_ComConsultarComisiones = True '20111122CAGP$001
                    Case 64
                        GLOBAL_ImportarVtas = True
                    Case 65
                        GLOBAL_Trasiego = True
                    Case 66
                        GLOBAL_InventarioFisicoActaCierre = True                    
                    Case 67
                        GLOBAL_CancelacionTomaIActaCierre = True
                    Case 68
                        GLOBAL_CancelacionControlRecipientesActaCierre = True
                    Case 69
                        GLOBAL_AccesoReportesAtaCierre = True
                    Case 70
                        GLOBAL_AltaActaCierre = True
                    Case 71
                        GLOBAL_CierreActaCierre = True
                    Case 72
                        GLOBAL_CancelacionActaCierre = True
                    Case 73
                        GLOBAL_ModificarControlRecipientesActaCierre = True
                    Case 74
                        GLOBAL_AbrirActaCierre = True


                End Select
            Next
        Catch err As Exception
            MessageBox.Show("Ocurrió el siguiente error:" & Chr(13) & err.ToString, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        sqlQuery.Connection.Close()
        Return True
    End Function
#End Region

    '20060201CFSL$001   -   EMPIEZA
    'Private Sub EmpresaCelula()
    '    Dim oEmpresa As New PortatilClasses.Consulta.nombreEmpresa(1, GLOBAL_Celula)
    '    oEmpresa.CargaDatos()
    '    GLOBAL_Empresa = CType(oEmpresa.Identificador, Byte)
    '    GLOBAL_Sucursal = oEmpresa.Sucursal ' 20060109CAGP$001
    '    oEmpresa = Nothing
    'End Sub
    '20060201CFSL$001   -   TERMINA

    Private Sub CorporativoDetalle(ByVal Parametros As Collection)  '20060201CFSL$001
        GLOBAL_DetalleEmpresa = CType(Parametros("NumEmpresaDetalle"), String).Trim '20060201CFSL$001
        Try
            Dim i As Integer
            If CType(GLOBAL_DetalleEmpresa, Short) > 1 Then
                For i = 1 To CType(GLOBAL_DetalleEmpresa, Short)
                    Dim Empresa As String
                    Dim NumEmpresa As String
                    Empresa = "Empresa" & CType(i, String)
                    NumEmpresa = CType(Parametros(Empresa), String).Trim '20060201CFSL$001
                    GLOBAL_DetalleEmpresas.Add(NumEmpresa)
                Next
            End If
        Catch
            GLOBAL_DetalleEmpresa = "0"
        End Try
    End Sub

    Public Sub Main()
        GLOBAL_Modulo = 16
        Dim frmSplash As New frmSplash()

        '20060201CFSL$001   -   EMPIEZA

        '20060327CFSL#002 / INICIO
        Dim img As Bitmap = Nothing
        Try
            img = New Bitmap(Application.StartupPath + "\ControlMovimientos.ico")
        Catch ex As Exception
        End Try
        '20060327CFSL#002 / FIN

        Dim frmAcceso As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y Administracion.exe.config", True, GLOBAL_Modulo, img)
        frmSplash.ShowDialog()

        If frmAcceso.ShowDialog() = DialogResult.OK Then
            Dim oSeguridad As New SigaMetClasses.Seguridad(GLOBAL_Modulo, frmAcceso.CadenaConexion, frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada)
            Try
                '20060327CFSL#001 / INICIO
                'Dim Updater As New SIGAMETSecurity.Updater(16, Application.ProductVersion, Application.StartupPath, frmAcceso.Conexion)
                'If Updater.Desactualizado Then
                '    Application.Exit()
                '    End
                'End If

                Dim Updater As New SIGAMETSecurity.Updater(16, Application.ProductVersion, Application.StartupPath, oSeguridad.CadenaConexion)
                '20060327CFSL#001 / FIN

                GLOBAL_CajaUsuario = oSeguridad.Caja
                GLOBAL_IDEmpleado = oSeguridad.Empleado
                GLOBAL_Usuario = oSeguridad.UserID
                GLOBAL_UsuarioNombre = oSeguridad.UsuarioNombre
                GLOBAL_Password = oSeguridad.Password
                GLOBAL_Servidor = oSeguridad.Servidor
                GLOBAL_BaseDatos = oSeguridad.BaseDatos
                GLOBAL_Celula = oSeguridad.Celula
                GLOBAL_Empresa = CType(oSeguridad.Corporativo, Byte)
                GLOBAL_Sucursal = oSeguridad.Sucursal

                GLOBAL_CelulaDescripcion = oSeguridad.CelulaDescripcion
                GLOBAL_ConString = oSeguridad.CadenaConexion
                GLOBAL_Conexion = New SqlConnection(GLOBAL_ConString)

                'Asignacion variable Paco
                Dim oConfigFactor As New SigaMetClasses.cConfig(5, CShort(GLOBAL_Empresa), GLOBAL_Sucursal)
                GLOBAL_FactorDensidad = CType(CType(oConfigFactor.Parametros("FactorDensidad"), String).Trim, Decimal)

                GLOBAL_RutaReportes = CType(oSeguridad.Parametros("RutaReportesW7"), String).Trim
                'GLOBAL_RutaReportes = "D:\Documents and Settings\cpatiño\Mis documentos\Documents\Programas Gasera\Proyecto 2\Reportes en rpt"

                GLOBAL_VersionAutorizada = CType(oSeguridad.Parametros("VersionAutorizada"), String).Trim
                GLOBAL_MensajeVersion = CType(oSeguridad.Parametros("MensajeVersion"), String).Trim
                GLOBAL_BasculaInstalada = CType(oSeguridad.Parametros("BasculaInstalada"), String).Trim
                If GLOBAL_BasculaInstalada = "1" Then ' 20060719CAGP$001
                    GLOBAL_PesoEmbarqueBasculaEmpresa = CType(oSeguridad.Parametros("PesoEmbarqBasculaEmpresa"), String).Trim
                End If
                GLOBAL_Ducto = CType(oSeguridad.Parametros("Ducto"), String).Trim
                GLOBAL_Imprimir = CType(oSeguridad.Parametros("Imprimir"), String).Trim
                GLOBAL_ModuloIntegrado = CType(oSeguridad.Parametros("ModuloIntegrado"), String).Trim
                GLOBAL_PlantaUnica = CType(oSeguridad.Parametros("PlantaUnica"), String).Trim
                GLOBAL_EmpresaComisionista = CType(oSeguridad.Parametros("EmpresaComisionista"), String).Trim
                GLOBAL_IncrementaTotalizador = CType(oSeguridad.Parametros("IncrementarTotalizador"), String).Trim '20060303CAGP$001
                GLOBAL_PorcentajePermitido = CType(oSeguridad.Parametros("PorcentajePermitido"), Decimal) '20070706CAGP$004

                'Variable PACO para la MedicionFisica
                GLOBAL_MaxDiasMovEmbarque = CType(CType(oSeguridad.Parametros("MaxDiasMovEmbarque"), String).Trim, Short)
                GLOBAL_MedicionFisica = CType(CType(oSeguridad.Parametros("MedicionFisica"), String).Trim, Boolean)
                GLOBAL_ImprimirFisicoTraslado = CType(oSeguridad.Parametros("ImprimirFisicoTraslado"), String).Trim() ' 20060118CAGP$002, 20070706CAGP$004
                GLOBAL_FechaHoraCierre = CType(oSeguridad.Parametros("FechaHoraCierre"), String).Trim()
                GLOBAL_TrasladosBascula = CType(oSeguridad.Parametros("LigarTrasladosPeso"), String).Trim() '20110809CAGP$001

                GLOBAL_SeguridadReportes = CType(oSeguridad.Parametros("SeguridadReportes"), Boolean)
                GLOBAL_RequiereArchivosGuia = CType(oSeguridad.Parametros("RequiereArchivosGuia"), Boolean)
                GLOBAL_ProveedorGasPorDefecto = CType(oSeguridad.Parametros("ProveedorGasPorDefecto"), Integer)
                CorporativoDetalle(oSeguridad.Parametros)
            Catch ArgEx As ArgumentException
                'GLOBAL_ModuloIntegrado = "0"
                MessageBox.Show("El sistema no puede leer la información del parámetro.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Finally


            End Try

            'If GLOBAL_VersionAutorizada <> Application.ProductVersion.ToString Then
            '    MessageBox.Show(GLOBAL_MensajeVersion, GLOBAL_Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            'EmpresaCelula()

            PortatilClasses.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, oSeguridad.CadenaConexion, GLOBAL_Empresa, GLOBAL_Sucursal)
            MedicionFisica.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, oSeguridad.CadenaConexion, GLOBAL_Empresa, GLOBAL_Sucursal)
            ClienteZonaEconomica.Globals.GetInstance.ConfiguraModulo(GLOBAL_Usuario, GLOBAL_Password, oSeguridad.CadenaConexion, GLOBAL_RutaReportes, GLOBAL_Empresa, GLOBAL_Sucursal, GLOBAL_Servidor, GLOBAL_BaseDatos)

            '20060201CFSL$001   -   EMPIEZA

            If CargarPrvilegios() Then
                Application.Run(New frmPrincipal())
            End If


        End If
    End Sub

End Module
