# Revisión técnica de Groomers

La versión de portafolio conserva C#, Windows Forms, .NET Framework 4.7.2, Entity Framework 6.5.1 y el modelo de tres capas del trabajo académico. Los archivos originales se mantienen en su carpeta de origen.

## Correcciones incorporadas

| Área | Corrección |
| --- | --- |
| Autenticación | Hash PBKDF2-HMAC-SHA256 con sal aleatoria y 600.000 iteraciones; ya no se comparan ni guardan contraseñas como texto |
| Sesión | Un acceso fallido y el cierre del menú limpian el usuario activo |
| Instalación | El script exige una base nueva, no contiene `DROP DATABASE` y rechaza una existente |
| Privacidad | Datos ficticios y dominios `example.invalid`; se retiraron los registros personales del script original |
| Citas | Identificadores reales de mascota, veterinario, medicamento y cita; código generado por SQL Server; restauración de las selecciones al editar |
| Disponibilidad | Validación y dos índices únicos filtrados que rechazan coincidencias exactas de horario |
| Mascotas | Sexo incluido al registrar; reasignación del propietario persistida; validación de edad y peso |
| Veterinarios y medicamentos | Selección de la fila para edición; identificadores correctos y parámetros del registro de acciones en su orden correcto |
| Propietarios | Validación de longitud y formato de entradas, selección de la fila para edición |
| Reportes | Rango inclusivo por días, rechazo de rangos invertidos y consulta tolerante a mascotas archivadas |
| Presentación | Campos de contraseña ocultos y tablas de citas y reportes de solo lectura |

## Verificación realizada

- Recompilación de las tres capas en Release sin errores ni advertencias.
- Instalación del esquema en una base nueva contra SQL Server local.
- Comprobación de rechazo del instalador ante una base existente, sin borrar sus registros.
- 16 comprobaciones: sal aleatoria, contraseña válida, contraseña inválida, rechazo de texto plano, hash malformado, acceso contra SQL Server, validación del administrador, sesión fallida, rango con todas las horas del día final, rango invertido, reserva duplicada, cambio de propietario persistido, tres enlaces de identificadores de formularios y generación de reporte en el formulario.
- Capturas de siete formularios reales con datos ficticios.

## Límites

Estas comprobaciones no constituyen una prueba completa de aceptación ni una evaluación de seguridad integral. La aplicación mantiene el alcance de un prototipo académico. No hay validación de duración o solapamiento de consultas, contabilidad de pagos, decremento automático de stock, exportación de reportes, recordatorios ni permisos granulares por rol. El cuadro de confirmación del administrador conserva el mecanismo académico original y debería sustituirse por un flujo de autorización completo para un uso operativo.

Los contextos de datos de varios módulos permanecen asociados a su instancia de clase; una revisión posterior puede reducir su vida útil y unificar transacciones entre cambios y bitácora en todos los módulos. La bitácora de las citas sí comparte la operación de persistencia.

## Referencias técnicas

- [Almacenamiento de contraseñas de OWASP](https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html).
- [Rfc2898DeriveBytes de Microsoft](https://learn.microsoft.com/dotnet/api/system.security.cryptography.rfc2898derivebytes).
