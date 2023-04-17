const bodyPart = location.pathname.replace('/exercises/', '');

    
    const optionsTwo = {
        method: 'GET',
        headers: {
            'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
            'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
        }
    };

console.log(encodeURI(location.pathname.replace('/exercises/', '')), "path name")


    fetch(`https://exercisedb.p.rapidapi.com/exercises/bodyPart/${bodyPart}`, optionsTwo)
        .then(response => response.json())
        .then(data=> {
            const apiData = data;
            var node = document.createElement('ul');
            apiData.forEach(item => {
                var listItem = document.createElement('li');
                // console.log(apiData, "api data object"); // this works
                var exerciseName = document.createElement('button');
                exerciseName.id = item.id
                console.log(exerciseName.id, 'button with  the id')
                exerciseName.classList.add('accordion-item')
                exerciseName.innerText= item.name;
                listItem.appendChild(exerciseName)
                node.appendChild(listItem);

                exerciseName.addEventListener('click', ViewOneExercise)
                // console.log(node, "whole unordered list");
            }) 

            var container = document.querySelector('#exercises');
            container.appendChild(node);
            
        })
        .catch(err => console.error(err));

    
function ViewOneExercise(event) {
    console.log(event,  'this is the event!')
    const exerciseName= event.target.innerHTML
    fetch(`https://exercisedb.p.rapidapi.com/exercises/bodyPart/${bodyPart}`, optionsTwo)
        .then(response => response.json())
        .then(data => {
            const exerciseData = data;
            exerciseData.forEach(exercise => {
                if (exercise.name == exerciseName) {
                    event.target.id = exercise.id
                    console.log(exercise.id, event.target.id)
                    const button = event.target
                    console.log(button, 'button that is being acted on in event')
                    function redirectToPath() {
                        window.location.href = `/exercises/${bodyPart}/${button.id}`; // Replace with the path you want to redirect to
                    }
                    redirectToPath()
                    // button.addEventListener('click', function(){
                    //     var path = event.view.location.pathname
                    //     console.log(path)
                    //     // event.view.location.pathname = `exercises/${bodyPart}/${exercise.id}`
                    // })
                }
            })
        })
}