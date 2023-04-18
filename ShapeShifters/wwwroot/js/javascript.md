




        const options = {
	method: 'GET',
	headers: {
		'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
		'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
	}
};

function GetBodyPart()  {
    apiUrl = 'https://exercisedb.p.rapidapi.com/exercises/bodyPart/'
    let apiUrlArr = [];
    let itemArr = [];
    fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
    .then(response => response.json())
    .then(data => {
        var listData = data;
        listData.forEach(item => {
            itemArr.push(item);
            if (item.includes(' ')){
                item =  item.replace(' ', '%20')
            }
            apiUrlArr.push(item);
            console.log(apiUrlArr, itemArr);
        })
    })
    return apiUrl, apiUrlArr, itemArr;

}

GetBodyPart();

function BodyPartInfo() {
    apiUrlArr.forEach
}


fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
	.then(response => response.json())
	.then(data => {
        const responseData = data;
        const exercise = document.querySelector('#exercise');
        exercise.innerHTML = responseData;
    })
	.catch(err => console.error(err));

fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
    .then(response => response.json())
    .then(data => {
        // console.log(data, "Shows the API data"); 
        const listData = data;
        var node = document.createElement('ul');
        // const listContainer = "hello";xs

        listData.forEach(item =>{
            // console.log(item, "Shows item from API data list");
            var listItem = document.createElement('li');
            var a = document.createElement('a');
            a.href= '/exercises/'+item;
            a.innerText = item;
            listItem.appendChild(a);
            // console.log(listItem, "Shows each  li element created in forEach loop");
            node.appendChild(listItem);
            // console.log(node, "Shows entire ul element");
        })

        var container = document.querySelector('#ul');
        container.appendChild(node);
        // container.innerHTML = node;
    })
    .catch(err => console.error(err));


    const optionsTwo = {
        method: 'GET',
        headers: {
            'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
            'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
        }
    };


    fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPart/back', optionsTwo)
        .then(response => response.json())
        .then(data=> {
            const apiData = data;
            var node = document.createElement('ul');
            apiData.forEach(item => {
                console.log(apiData, "api data object"); // this works
                var exerciseName = document.createElement('li');
                exerciseName.innerText= item.name;
                node.appendChild(exerciseName);
                console.log(node, "whole unordered list");
            }) 

            var container = document.querySelector('#exercises');
            container.appendChild(node);
            
        })
        .catch(err => console.error(err));