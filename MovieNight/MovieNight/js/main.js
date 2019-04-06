$(document).ready(() => {
    let imdbNumber = 'tt2015381';
    favoriteMovie(imdbNumber);
    
 });

function favoriteMovie(imdbNumber) {

    axios.get('http://www.omdbapi.com?i=' + imdbNumber + '&apikey=b9bb3ece')
        .then((response) => {
            console.log(response);
            let movies = response.data.Poster;
            let output = '';

            output += `
                <img src="${movies}">
            `;
           

            $('#accountImage').html(output);
        })
        .catch((err) => {
            console.log(err);
        });
}