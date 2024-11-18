document.getElementById('login').addEventListener('submit', async function (e) {
    e.preventDefault();

    const messageLogin = document.getElementById('message');
    messageLogin.innerHTML = '';

    const username = document.getElementById('userInputText').value;
    const password = document.getElementById('inputPassword1').value;
    


    // Validaciones
    if (!username) {
        messageLogin.innerHTML = '<p style="color: red;">El username es requerido.</p>';
        return;
    }
    if (!password) {
        messageLogin.innerHTML = '<p style="color: red;">La contraseña es requerida.</p>';
        return;
    }

    const login = {
        UserName: username,
        Password: password,
        
    };

    try {
        
        const response = await fetch('https://localhost:7025/api/Login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
               
            },
            body: JSON.stringify(login),
        });

        if (!response.ok) {
            messageLogin.innerHTML = `<p style="color: red;">Error: ${errorData.message || 'Ocurrió un error al ingresar.'}</p>`;
        }

        const res = await response.json();
        const token = res.token;
        
        if (res.role === "estudiante") {
            localStorage.setItem("token", token);
          
            window.location.href = "views/Student.html";
        } else {
            messageLogin.innerHTML = '<p style="color: red;">Acceso denegado.</p>';
        }
        
    } catch (error) {
        messageLogin.innerHTML = `<p style="color: red;">Error: ${error.message || 'No se pudo conectar con el servidor.'}</p>`;
    }
});
