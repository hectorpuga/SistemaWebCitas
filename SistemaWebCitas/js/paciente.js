/*************************************************
 *  paciente.js
 *  Carga la lista de pacientes en la DataTable
 *************************************************/

/* ---------- 1. AJAX ---------- */
function sendDataAjax() {
    $.ajax({
        type: "POST",
        url: "frmGestionarPaciente.aspx/ListarPacientes",
        data: JSON.stringify({}),                       // WebMethod vacío
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            console.log("Éxito:", data.d);
            addRowsDT(data.d);                          // ← añade los datos
        },
        error: function (xhr, _, err) {
            console.error(xhr.status, xhr.responseText, err);
        }
    });
}

/* ---------- 2. Inicializa la DataTable una sola vez ---------- */
var tablaPacientes = null;

$(document).ready(function () {
    tablaPacientes = $("#tbl_pacientes").DataTable({
        columns: [
            { data: "idPaciente" },                                   // Código
            { data: "Nombres" },                                      // Nombres
            {                                                         // Apellidos
                data: null,
                render: d => `${d.ApPaterno} ${d.ApMaterno}`
            },
            {                                                         // Sexo
                data: "Sexo",
                render: d => d === "M" ? "Masculino" : "Femenino"
            },
            { data: "Edad" },                                         // Edad
            { data: "Direccion" },                                    // Dirección
            {                                                         // Estado
                data: "Estado",
                render: d => d ? "Activo" : "Inactivo"
            }
        ],
        language: {                                                  // Español básico
            emptyTable: "Sin datos disponibles"
        }
    });

    // Llamada AJAX después de inicializar
    sendDataAjax();
});

/* ---------- 3. Pinta/actualiza la tabla ---------- */
function addRowsDT(listado) {
    tablaPacientes.clear();           // Limpia la tabla
    tablaPacientes.rows.add(listado); // Carga todo el array de objetos
    tablaPacientes.draw();            // Redibuja
}

/* ---------- 4. Funciones de prueba estáticas (opcional) ---------- */
function templateRow() {
    return `<tr>
                <td>123</td>
                <td>Héctor Puga</td>
                <td>Puga Puga</td>
                <td>M</td>
                <td>15</td>
                <td>xicotencatl</td>
                <td>Activo</td>
            </tr>`;
}

function addRowTodDataTable() {
    const $tbody = $("#tbl_body_table");
    for (let i = 0; i < 10; i++) {
        $tbody.append(templateRow());
    }
}
// addRowTodDataTable(); // Descomenta si quieres ver filas demo
