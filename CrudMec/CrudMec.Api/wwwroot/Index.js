// JavaScript source code
document.addEventListener('DOMContentLoaded', async function () {
    console.log('Cargando materias...');
    await loadMatters();
});
function redirectLogin() {
    window.location.href = "views/Login.html"; 
}
function redirectProfile() {
    window.location.href = "views/Student.html";
} 

function redirectRegisters() {
    window.location.href = "views/Student.html";
} 

/*Add data Student*/
const messagestudent = document.getElementById('message');
messagestudent.innerHTML = ''; 

document.getElementById('createStudent').addEventListener('submit', async function (e) {
    e.preventDefault();

    const name = document.getElementById('nameInputText').value.trim();
    const lastName = document.getElementById('lastNameInputText').value.trim();
    const profileStudent = document.getElementById('profile').value;
    const phone = parseInt(document.getElementById('phoneInputText').value.trim());
    const email = document.getElementById('emailInputEmail').value.trim();
    const birthDate = document.getElementById('dateOfBirthInputDate').value;
    const selectedOptionMatter = Array.from(document.querySelectorAll('#matterCheckDefault input[type="checkbox"]:checked')).map(checkbox => checkbox.value);

    // Validaciones
    if (!name) {
        messagestudent.innerHTML = '<p style="color: red;">ddEl nombre debe tener al menos 3 caracteres.</p>';
        return;
    }
    if (!lastName || lastName.length < 3) {
        messagestudent.innerHTML = '<p style="color: red;">El apellido debe tener al menos 3 caracteres.</p>';
        return;
    }
    if (!validateEmail(email)) {
        messagestudent.innerHTML = '<p style="color: red;">El correo electrónico no es válido.</p>';
        return;
    }
    if (!birthDate || !validDate(birthDate)) {
        messagestudent.innerHTML = '<p style="color: red;">Debe ingresar una fecha válida.</p>';
        return;
    }

    if (selectedOptionMatter.length != 3) {
        messagestudent.innerHTML = '<p style="color: red;">Debe seleccionar 3 materias..</p>';
        return;
    }
    if (!profileStudent || profileStudent === 'Seleccione un perfil') {
        messagestudent.innerHTML = '<p style="color: red;">Debe seleccionar un perfil.</p>';
        return;
    }
    const student = {
        Name:name,
        LastName:lastName,
        profile: profileStudent,
        PhoneNumber:phone,
        Email:email,
        DateOfBirth:birthDate,
        selectedOptions: selectedOptionMatter 
    };

    try {
        const response = await fetch('https://localhost:7025/Student', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(student),
        });

        if (response.ok) {
            messagestudent.innerHTML = '<p style="color: green;">Estudiante creado satisfactoriamente.</p>';
        } else if (response.status === 400) {
            const errorData = await response.json();
            messagestudent.innerHTML = `<p style="color: red;">Error:El profesor con ID  ${response.id} no puede dictar más de 2 materias.</p>`;
        } else {
            const errorData = await response.json();
            messagestudent.innerHTML = `<p style="color: red;">Error: ${errorData.message || 'Ocurrió un error al crear el estudiante.'}</p>`;
        }
    } catch (error) {
        messagestudent.innerHTML = `<p style="color: red;">Error: ${error.message || 'No se pudo conectar con el servidor.'}</p>`;
    }
});

async function loadMatters() {
   
    try {
        const response = await fetch('https://localhost:7025/Matter');
        if (!response.ok) throw new Error("Error al cargar materia");

        const matters = await response.json();

        const checkboxContainer = document.getElementById('matterCheckDefault');
        checkboxContainer.innerHTML = ''; 

     
        const defaultDiv = document.createElement('div');
        defaultDiv.classList.add('mb-3');

        const defaultCheckbox = document.createElement('input');
        defaultCheckbox.classList.add('form-check-input');
        defaultCheckbox.type = 'checkbox';
        defaultCheckbox.value = ''; 
        defaultCheckbox.id = 'flexCheckDefault';

        const defaultLabel = document.createElement('label');
        defaultLabel.classList.add('form-check-label');
        defaultLabel.setAttribute('for', 'flexCheckDefault');
        defaultLabel.textContent = 'Seleccione una materia';

        defaultDiv.appendChild(defaultCheckbox);
        defaultDiv.appendChild(defaultLabel);
        checkboxContainer.appendChild(defaultDiv);

        
        matters.forEach(matter => {
            const div = document.createElement('div');
            div.classList.add('mb-3');

            const checkbox = document.createElement('input');
            checkbox.classList.add('form-check-input');
            checkbox.type = 'checkbox';
            checkbox.value = matter.materiaId;
            checkbox.id = `flexCheck${matter.materiaId}`;

            const label = document.createElement('label');
            label.classList.add('form-check-label');
            label.setAttribute('for', `flexCheck${matter.materiaId}`);
            label.textContent = matter.name;

            div.appendChild(checkbox);
            div.appendChild(label);
            checkboxContainer.appendChild(div);
        });

    } catch (error) {
        console.error('Error al cargar materias:', error);
    }
}

function validateEmail(email) {
    const regex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    return regex.test(email);
}
function validDate(dateString) {
    const date = new Date(dateString);
    return !isNaN(date.getTime());
}