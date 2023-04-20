// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const options = {
	method: 'GET',
	headers: {
		'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
		'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
	}
};
const another = {
	method: 'GET',
	headers: {
		'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
		'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
	}
};
// fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
// 	.then(response => response.json())
// 	.then(data => {
//         const responseData = data;
//         const exercise = document.querySelector('#exercise');
//         exercise.innerHTML = responseData;
//     })
// 	.catch(err => console.error(err));

fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', another)
    .then(response => response.json())
    .then(data => {
        // console.log(data, "Shows the API data"); 
        const listData = data;
        var node = document.createElement('ul');
        node.classList.add('list-group', 'text-center')
        node.classList.add('list-unstyled')
        // const listContainer = "hello";xs

        listData.forEach(item =>{
            // console.log(item, "Shows item from API data list");
            var listItem = document.createElement('li');
            var a = document.createElement('a');
            a.classList.add('list-group-item')
            a.classList.add('list-group-item-action')
            a.href= '/exercises/'+item;
            // console.log(a.href, 'link') //! may need to be changed to correctly add href to button
            a.setAttribute('id', item);
            a.innerText = item;
            // a.addEventListener('click', GetBodyPart);
            // a.preventDefault();
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

    function GetBodyPart(event)  {
        console.log(event, "this is the EVENT")
        const bodyPart = event.target.id.replace(' ', '%20')


        const optionsTwo = {
            method: 'GET',
            headers: {
                'X-RapidAPI-Key': '9f004f230amshc794c57523e95d5p15f2e1jsn0a1acb38ad1d',
                'X-RapidAPI-Host': 'exercisedb.p.rapidapi.com'
            }
        };
    
    
        fetch(`https://exercisedb.p.rapidapi.com/exercises/bodyPart/${bodyPart}`, optionsTwo)
            .then(response => response.json())
            .then(data=> {
                const apiData = data;
                var node = document.createElement('ul');
                apiData.forEach(item => {
                    // console.log(apiData, "api data object"); // this works
                    var exerciseName = document.createElement('li');
                    exerciseName.innerText= item.name;
                    node.appendChild(exerciseName);
                    // console.log(node, "whole unordered list");
                }) 
    
                var container = document.querySelector('#exercises');
                container.appendChild(node);
                
            })
            .catch(err => console.error(err));
        // apiUrl = 'https://exercisedb.p.rapidapi.com/exercises/bodyPart/'
        // let apiUrlArr = [];
        // let itemArr = [];
        // fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
        // .then(response => response.json())
        // .then(data => {
        //     var listData = data;
        //     listData.forEach(item => {
        //         itemArr.push(item);
        //         if (item.includes(' ')){
        //             item =  item.replace(' ', '%20')
        //         }
        //         item = apiUrl + item;
        //         apiUrlArr.push(item);
        //         console.log(apiUrlArr, itemArr, 'arrays from getBodyPart');
        //     })
        //     for(let i=0; i<listData.length; i++){
        //         for(let x=0; x<itemArr.length; x++){
        //             if (listData[i] == itemArr[x]){
        //                 if(itemArr[x].includes(' ')){
        //                     itemArr[x] = itemArr[x].replace(' ', '%20')
        //                 }
        //                 if(listData[i] == document.getElementById('#${itemArr[x]}')){
        //                     for(let y=0; y<apiUrlArr.length; y++){
        //                         if(x == y){

        //                             console.log(apiUrlArr[y], 'endpoint')
        //                         }
        //                     }
        //                 }
        //             }
        //         }
        //     }
        //     return apiUrl, apiUrlArr, itemArr;
        // })
        
    
    }
    
    // GetBodyPart();
    // // console.log(itemArr, 'this is the ITEM ARRAY')
    
    // function BodyPartInfo() {
    //     fetch('https://exercisedb.p.rapidapi.com/exercises/bodyPartList', options)
    //     .then(response => response.json())
    //     .then(data => {
    //         var listData = data;
    //         // var apiString
    //         for(let i=0; i<listData.length; i++){
    //             for(let x=0; x<itemArr.length; x++){
    //                 if (listData[i] == itemArr[x]){
    //                     if(itemArr[x].includes(' ')){
    //                         itemArr[x] = itemArr[x].replace(' ', '%20')
    //                     }
    //                     if(listData[i] == document.querySelector('#${item}')){
    //                         for(let y=0; y<apiUrlArr.length; y++){
    //                             if(x == y){

    //                                 console.log(apiUrlArr[y])
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //     })
    // }
    
   


