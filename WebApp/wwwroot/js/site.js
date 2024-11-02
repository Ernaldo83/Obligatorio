

function NavegadorCliente() {
    console.log("cliente")
}

function NavegadorAdministrador() {
    console.log("administrador")
}
function crearNodo(NodoPadre, tipoNodo, array) {
    let nodo = document.createElement(tipoNodo);
    if (array != undefined) {
        for (let i = 0; i < array.length; i++) {
            let esCheckboxActivo = true;
            if (array[i] == "checked") { if (!array[i + 1]) { esCheckboxActivo = false } }
            if (array[i] != "innerHTML" && esCheckboxActivo) {
                if (array[array.length - 2] != "click" || array[array.length - 2] != "keyup" || array[array.length - 2] != "change") {
                    nodo.setAttribute(array[i], array[i + 1]);
                }
            }
            if (array[i] == "innerHTML") { nodo.innerHTML = array[i + 1] };
            if (array[i] == "click" || array[i] == "keyup" || array[i] == "change") {
                nodo.addEventListener(array[i], array[i + 1]);
            }
            i++;
        }
    }
    NodoPadre.appendChild(nodo);
    return nodo;
}
