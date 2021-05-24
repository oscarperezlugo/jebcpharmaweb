function cierreButton() {
    let cierreButton = document.querySelectorAll('.botonsubmit');
    for (let i = 0; i < cierreButton.length; i++) {
        cierreButton[i].addEventListener('click', () => {
            
            alert("Gracias por Tu Compra");
            localStorage.clear();
            location.href = 'Default.aspx';
        });
    }

}
cierreButton();