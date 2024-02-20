function GetDateTime() {
    const date = new Date();
    let day = date.getDate();
    let month = date.getMonth();
    let year = date.getFullYear();
    return `${day}-${month}-${year}`;
} 
