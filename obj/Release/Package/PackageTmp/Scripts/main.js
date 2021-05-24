let carts = document.querySelectorAll('.botonagregar');
var tits = document.querySelectorAll('#cajatitulo');  
let Direccioncli;
let Cliente;
let Correo;
let GuidCliente;
let Fila;
let Telefono;
let iDventa;
iDventa = create_UUID();
let products;

async function getjson() {
    
    var requestOptions = {
        method: 'GET',
        redirect: 'follow',
        mode: 'cors'
    };

    products = await fetch("https://jebcpharma.somee.com/api/api/Productoes1", requestOptions)
        .then(response => response.text())        
        .then(result => JSON.parse(result))               
        .catch(error => console.log('error', error));    
}
function getProduct(i) {
    
    let seleccionado = tits[i].textContent.toLocaleLowerCase().replace(/ /g, '').trim();
    var result = products.find(x => x.Tag === seleccionado);
    cartNumbers(result);
    totalCost(result);
    displaycart();       
}




for (let i = 0; i < carts.length; i++) {
    
    
    carts[i].addEventListener('click', () => {
                     
        if (GuidCliente != null) {
                     
            getProduct(i);
            
        }
        else {
            alert("Debes Iniciar Sesion");
            location.href = "Login.aspx";
        }
    })
}
function onLoadCartNumbers(){
    let productNumbers = localStorage.getItem('cartNumbers');
    if (productNumbers) {
        document.querySelector('#botoncarrito span').textContent = productNumbers;
    }
}
function cartNumbers(product, action) {    
    let productNumbers = localStorage.getItem('cartNumbers');
    productNumbers = parseInt(productNumbers);
    let cartItems = localStorage.getItem('productsInCart');
    cartItems = JSON.parse(cartItems);
    
    if (action) {
        localStorage.setItem("cartNumbers", productNumbers - 1);
        document.querySelector('#botoncarrito span').textContent = productNumbers - 1;
        console.log("action running");
    } else if (productNumbers) {
        localStorage.setItem("cartNumbers", productNumbers + 1);
        document.querySelector('#botoncarrito span').textContent = productNumbers + 1;
    } else {
        localStorage.setItem("cartNumbers", 1);
        document.querySelector('#botoncarrito span').textContent = 1;
    }
    setItems(product);
    
}
function setItems(product) {    
    let cartItems = localStorage.getItem('productsInCart');
    cartItems = JSON.parse(cartItems);
    if (cartItems != null) {        
        let currentProduct = product.Tag;        
        if (cartItems[currentProduct] == undefined) {
            cartItems = {
                ...cartItems,
                [currentProduct]: product
            }
        }
        cartItems[currentProduct].inCart += 1;
    } else {    
        product.inCart = 1;
        cartItems = {
            [product.Tag]: product
        }
    }
    localStorage.setItem("productsInCart", JSON.stringify(cartItems));
}
function totalCost(product, action) {    
    let cart = localStorage.getItem("totalCost");
    if (action) {
        cart = parseFloat(cart);

        localStorage.setItem("totalCost", cart - product.PrecioD);
    } else if (cart != null) {

        cart = parseFloat(cart);
        localStorage.setItem("totalCost", cart + product.PrecioD);

    } else {
        localStorage.setItem("totalCost", product.PrecioD);
    }
}
function displaycart() {
    let cartItems = localStorage.getItem("productsInCart");
    cartItems = JSON.parse(cartItems);  
    let cartCost = localStorage.getItem('totalCost');
    cartCost = parseFloat(cartCost);
      
    let productsContainer = document.querySelector(".productslist");    
    if (cartItems && productsContainer) {
        productsContainer.innerHTML = '';
        Object.values(cartItems).map((item, index) => {
            productsContainer.innerHTML += `
            <div class="product">
            <ion-icon name="close-circle-outline"></ion-icon>
            <span>${item.Producto1}</span>
            </div>
            <div class="productprice">$${item.PrecioD}</div>
            <div class="quantity"><ion-icon class="decrease" name="caret-back-outline"></ion-icon><span>${item.inCart}</span><ion-icon class="increase" name="caret-forward-outline"></ion-icon></div>
            <div class="totalcost">$${item.PrecioD * item.inCart}</div>
            `;
        });
        productsContainer.innerHTML += `
            <div class="totalcontainer">
                <h4 class="totaltitle">"TOTAL"</h4>
                <h4 class="totalvalue">$${cartCost}</h4>
                </div>`
        deleteButtons();
        manageQuantity();
    }
}
function manageQuantity() {
    let decreaseButtons = document.querySelectorAll('.decrease');
    let increaseButtons = document.querySelectorAll('.increase');
    
    let currentQuantity = 0;
    let currentProduct = '';
    let cartItems = localStorage.getItem('productsInCart');
    cartItems = JSON.parse(cartItems);
    
    for (let i = 0; i < increaseButtons.length; i++) {
        decreaseButtons[i].addEventListener('click', () => {
            console.log(cartItems);
            currentQuantity = decreaseButtons[i].parentElement.querySelector('span').textContent;
            console.log(currentQuantity);
            currentProduct = decreaseButtons[i].parentElement.previousElementSibling.previousElementSibling.querySelector('span').textContent.toLocaleLowerCase().replace(/ /g, '').trim();
            console.log(currentProduct);
            
            if (cartItems[currentProduct].inCart > 1) {
                cartItems[currentProduct].inCart -= 1;
                cartNumbers(cartItems[currentProduct], "decrease");
                totalCost(cartItems[currentProduct], "decrease");
                localStorage.setItem('productsInCart', JSON.stringify(cartItems));
                displaycart();
            }
        });

        increaseButtons[i].addEventListener('click', () => {
            console.log(cartItems);
            currentQuantity = increaseButtons[i].parentElement.querySelector('span').textContent;
            console.log(currentQuantity);
            currentProduct = increaseButtons[i].parentElement.previousElementSibling.previousElementSibling.querySelector('span').textContent.toLocaleLowerCase().replace(/ /g, '').trim();
            console.log(currentProduct);

            cartItems[currentProduct].inCart += 1;
            cartNumbers(cartItems[currentProduct]);
            totalCost(cartItems[currentProduct]);            
            localStorage.setItem('productsInCart', JSON.stringify(cartItems));
            displaycart();
        });
    }
}
function deleteButtons() {
    let deleteButtons = document.querySelectorAll('.product ion-icon');
    let productNumbers = localStorage.getItem('cartNumbers');
    let cartCost = localStorage.getItem("totalCost");
    let cartItems = localStorage.getItem('productsInCart');
    cartItems = JSON.parse(cartItems);
    let productName;
    

    for (let i = 0; i < deleteButtons.length; i++) {
        deleteButtons[i].addEventListener('click', () => {
            productName = deleteButtons[i].parentElement.textContent.toLocaleLowerCase().replace(/ /g, '').trim();

            localStorage.setItem('cartNumbers', productNumbers - cartItems[productName].inCart);
            localStorage.setItem('totalCost', cartCost - (cartItems[productName].PrecioD * cartItems[productName].inCart));

            delete cartItems[productName];
            localStorage.setItem('productsInCart', JSON.stringify(cartItems));

            displaycart();
            onLoadCartNumbers();
        })
    }
}
function finButton() {
    let finButton = document.querySelectorAll('.botonfinalizar');            
    finButton[0].addEventListener('click', () => {                
        let lineas = localStorage.getItem('productsInCart');
        let totalfinal = localStorage.getItem('totalCost');
        let objetos = localStorage.getItem('cartNumbers');                        
        document.cookie = "venta= " + iDventa + "";
        lineas = JSON.parse(lineas);        
        Object.values(lineas).map((item, index) => {
            
                var myHeaders = new Headers();
                var envio = {
                    Producto: item.Producto1,
                    Cantidad: item.inCart,
                    Precio: item.PrecioD,
                    iDVenta: iDventa
                }                
                myHeaders.append("Content-Type", "application/json");
                var raw = JSON.stringify(envio);
                var requestOptions = {
                    method: 'POST',
                    headers: myHeaders,
                    body: raw,
                    redirect: 'follow'
                };

            fetch("https://jebcpharma.somee.com/api/api/Lineas", requestOptions)
                .then(response => response.text())                                
                .catch(error => console.log('error', error))
                
            
            
            
        });
        
        var myHeaders = new Headers();
        var cabecera = {
            iDCliente: GuidCliente,
            FechaVenta: new Date(),
            Monto: totalfinal,
            Lineas: objetos,
            SubTotal: totalfinal,
            iDVenta: iDventa,
            Status: "PAGO POR VERIFICAR"            

        }
        myHeaders.append("Content-Type", "application/json");
        var rawdos = JSON.stringify(cabecera);
        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: rawdos,
            redirect: 'follow'
        };

        fetch("https://jebcpharma.somee.com/api/api/Cabeceras", requestOptions)
            .then(response => response.text())
            .then(response => actCant())            
            .catch(error => console.log('error', error));
            

        
    });
        
}
function actCant() {
    let lineas = localStorage.getItem('productsInCart');
    lineas = JSON.parse(lineas);  
    Object.values(lineas).map((item, index) => {
        console.log("running");
        var myHeaders = new Headers();
        var envio = {
            TagDesc: item.Tag,
            CantidadDesc: item.inCart,

        }
        myHeaders.append("Content-Type", "application/json");
        var raw = JSON.stringify(envio);
        var requestOptions = {
            method: 'POST',
            headers: myHeaders,
            body: raw,
            redirect: 'follow'
        };

        fetch("https://jebcpharma.somee.com/api/api/Cantidad", requestOptions)
            .then(response => response.text())
            .then(response => moveCierre())
            .catch(error => console.log('error', error));
    });
}
function moveCierre() {
    location.href = "Cierre.aspx";
}
function getCookie(rowC) {
    var name = rowC + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = "{" + decodedCookie + "}";
    ca = JSON.stringify(ca);
    ca = JSON.parse(ca);
    var ca = decodedCookie.split(';');            
    var nombre = ca[0];
    var nombref = nombre.substring(nombre.indexOf("=") + 1);
    var id = ca[1];
    var idf = id.substring(id.indexOf("=") + 1);
    var correo = ca[2];
    var correof = correo.substring(correo.indexOf("=") + 1);
    var telefono = ca[3];
    var telefonof = telefono.substring(telefono.indexOf("=") + 1);
    var direccion = ca[4];
    var direccionf = direccion.substring(direccion.indexOf("=") + 1);
    var row = ca[5];
    var rowf = row.substring(row.indexOf("=") + 1);
    Cliente = nombref;
    GuidCliente = idf;
    Correo = correof;
    Telefono = telefonof;
    Direccioncli = direccionf;
    Fila = rowf;    
    return "";
    
}
function create_UUID() {
    var dt = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (dt + Math.random() * 16) % 16 | 0;
        dt = Math.floor(dt / 16);
        return (c == 'x' ? r : (r & 0x3 | 0x8)).toString(16);        
    });
    return uuid;
    
}

function catButton() {
    let catButton = document.querySelectorAll('.botoncat');    
    for (let i = 0; i < catButton.length; i++) {
        catButton[i].addEventListener('click', () => {
            let Categoria = catButton[i].textContent;
            
            document.cookie = "categ= " + Categoria + "";
            
            
            if (Categoria != null)
            {
                location.href = "Categorias.aspx";
            }
            
            
        })
    }

}
function searchButton() {
    let searchButton = document.querySelectorAll('.searchbut');    
    searchButton[0].addEventListener('click', () => {
        let searchvalue = document.getElementById("busqueda").value;
        document.cookie = "search= " + searchvalue + "";                        
    });

}


onLoadCartNumbers();

displaycart();

getjson();

finButton();

getCookie();

catButton();

searchButton();





