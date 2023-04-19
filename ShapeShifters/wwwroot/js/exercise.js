console.log('hello?')
const path  = window.location.pathname;
const parts = path.split('/')
const bodyPart = parts[2];
const optionsTwo = {
    method: 'GET',
    headers: {
        'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
        'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
    }
};
fetch(`https://exercisedb.p.rapidapi.com/exercises/bodyPart/${bodyPart}`, optionsTwo)
        .then(response => response.json())
        .then(data =>{
            const exerciseData = data;
            console.log(exerciseData)
            console.log(path)
            const exId = parts[3];
            console.log(exId, "id"); // "1234"
            exerciseData.forEach(item => {
                if (exId == item.id)  {
                    console.log(item, "what we are trying to display")
                    var node = document.createElement('div')
                    var getExerciseName = document.createElement('h1')
                    var getExerciseEquipment = document.createElement('p')
                    var getExerciseURL = document.createElement('img')
                    getExerciseName.innerText = item.name
                    getExerciseEquipment.innerText = item.equipment
                    getExerciseURL.src = item.gifUrl
                    node.appendChild(getExerciseName)
                    node.appendChild(getExerciseURL)
                    node.appendChild(getExerciseEquipment)
                    var container = document.querySelector('#oneEx')
                    container.appendChild(node);
                }
            })
        })
        .catch(err => console.error(err))