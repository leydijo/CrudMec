//----------------------------- Teacher

document.getElementById('createTeacher').addEventListener('submit', async function (e) {
    e.preventDefault();

    const messageTeacher = document.getElementById('message');
    messageTeacher.innerHTML = '';

    const nameTeacher = document.getElementById('nameTeacher').value.trim();
    const lastNameTeacher = document.getElementById('lastNameTeacher').value.trim();
    const phoneTeacher = parseInt(document.getElementById('phoneTeacher').value.trim());
    const emailTeacher = document.getElementById('emailTeacher').value.trim();
    const birthDateTeacher = document.getElementById('dateOfBirthTeacher').value;


    // Validaciones
    if (!nameTeacher) {
        messageTeacher.innerHTML = '<p style="color: red;">El nombre debe tener al menos 3 caracteres.</p>';
        return;
    }
    if (!lastNameTeacher || lastNameTeacher.length < 3) {
        messageTeacher.innerHTML = '<p style="color: red;">El apellido debe tener al menos 3 caracteres.</p>';
        return;
    }

    if (!validateEmail(emailTeacher)) {
        messageTeacher.innerHTML = '<p style="color: red;">El correo electrónico no es válido.</p>';
        return;
    }
    if (!birthDateTeacher || !validDate(birthDateTeacher)) {
        messageTeacher.innerHTML = '<p style="color: red;">Debe ingresar una fecha válida.</p>';
        return;
    }
    
    const teacher = {
        name:nameTeacher,
        LastName: lastNameTeacher,
        Email: emailTeacher,
        PhoneNumber: phoneTeacher,
        DateOfBirth:birthDateTeacher
    };

    try {
        const response = await fetch('https://localhost:7025/Teacher', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(teacher),
        });

        if (response.ok) {
            messageTeacher.innerHTML = '<p style="color: green;">Profesor creado satisfactoriamente.</p>';
        } else {

            const errorData = await response.json();
            messageTeacher.innerHTML = `<p style="color: red;">Error: ${errorData.message || 'Ocurrió un error al crear el profesor.'}</p>`;
        }
    } catch (error) {
        messageTeacher.innerHTML = `<p style="color: red;">Error: ${error.message || 'No se pudo conectar con el servidor.'}</p>`;
    }
});
function validateEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}
function validDate(dateString) {
    const date = new Date(dateString);
    return !isNaN(date.getTime());
}