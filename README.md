# PruebaTecnica.Net

GET -  http://localhost:5033/api/personas (listar)
POST - http://localhost:5033/api/personas (agregar)

Json de Prueba

{
    "documentoIdentidad": "123456789",
    "nombres": "Yefferson",
    "apellidos": "Linares",
    "fechaNacimiento": "2001-06-30",
    "numerosTelefonicos": [
        {
            "numero": "+1234567890",
            "personaDocumentoIdentidad": "123456789"
        },
        {
            "numero": "+0987654321",
            "personaDocumentoIdentidad": "123456789"
        }
    ],
    "correosElectronicos": [
        {
            "correo": "juan.perez@example.com",
            "personaDocumentoIdentidad": "123456789"
        },
        {
            "correo": "jperez@example.com",
            "personaDocumentoIdentidad": "123456789"
        }
    ],
    "direccionesFisicas": [
        {
            "direccion": "123 Main St",
            "personaDocumentoIdentidad": "123456789"
        },
        {
            "direccion": "456 Elm St",
            "personaDocumentoIdentidad": "123456789"
        }
    ]
}