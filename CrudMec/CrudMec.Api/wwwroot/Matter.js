//----------------------------- Matter
document.addEventListener('DOMContentLoaded', loadTeachers);
document.getElementById('createMatter').addEventListener('submit', async function (e) {
    e.preventDefault();

    const messageMatter = document.getElementById('message');
    messageMatter.innerHTML = '';

    const nameMatter = document.getElementById('nameMatter').value.trim();
    const credits = parseInt(document.getElementById('credits').value);
    const teacher = parseInt(document.getElementById('teacher').value);
   

    // Validaciones
    if (!nameMatter) {
        messageMatter.innerHTML = '<p style="color: red;">Materia  no puede estar vacío.</p>';
        return;
    }
    if (!credits || credits != 3) {
        messageMatter.innerHTML = '<p style="color: red;">El número de creditos por materia son 3.</p>';
        return;
    }

    if (!teacher || isNaN(teacher)) {
        messageMatter.innerHTML = '<p style="color: red;">Debe seleccionar un profesor válido.</p>';
        return;
    }
    const matter = {
        Name: nameMatter,
        Credits: credits ,
        TeacherId: teacher
    };

    try {
        const response = await fetch('https://localhost:7025/Matter', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(matter),
        });

        if (response.ok) {
            messageMatter.innerHTML = '<p style="color: green;">Materia creada satisfactoriamente.</p>';
        } else if (response.status === 400) {
            const errorData = await response.json();
            messagestudent.innerHTML = `<p style="color: red;">Error:El profesor con ID ${response.id } no puede dictar más de 2 materias.</p>`;
        }else {

            const errorData = await response.json();
            messageMatter.innerHTML = `<p style="color: red;">Error: ${errorData.message || 'Ocurrió un error al crear el profesor.'}</p>`;
        }
    } catch (error) {
        messageMatter.innerHTML = `<p style="color: red;">Error: ${error.message || 'No se pudo conectar con el servidor.'}</p>`;
    }
});

async function loadTeachers() {
    const teacherSelect = document.getElementById('teacher');
    try {
        const response = await fetch('https://localhost:7025/Teacher');
        if (response.ok) {
            const teachers = await response.json();
            teachers.forEach(teacher => {
                const option = document.createElement('option');
                option.value = teacher.id;
                option.textContent = `${teacher.name} ${teacher.lastName}`;
                teacherSelect.appendChild(option);
            });
        } else {
            teacherSelect.innerHTML = '<option value="">Error al cargar materias</option>';
        }
    } catch (error) {
        teacherSelect.innerHTML = '<option value="">Error al conectar con el servidor</option>';
    }
}
