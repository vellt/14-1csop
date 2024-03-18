const express= require('express');
const mysql= require('mysql');
const app = express();

const host='localhost';
const port =3000;

app.use(express.json());

let connection = mysql.createConnection({
    host: host, 
    user: 'root',
    password: '',
    database: 'tanfolyam'
});

app.get('/ertekelesek', (req, res) => {
    connection.query('SELECT * FROM ertekelesek', (err, results)=> {
        if(err) {
            console.log(err);
            res.send("hiba");
        }
        else {
            console.log(results);
            res.send(results);
        }
    });
});

app.get('/tantargyak', (req, res) => {
    connection.query('SELECT * FROM tantargyak', (err, results)=> {
        if(err) {
            console.log(err);
            res.send("hiba");
        }
        else {
            console.log(results);
            res.send(results);
        }
    });
});

app.get('/tanulok', (req, res) => {
    connection.query('SELECT * FROM tanulok', (err, results)=> {
        if(err) {
            console.log(err);
            res.send("hiba");
        }
        else {
            console.log(results);
            res.send(results);
        }
    });
});

// elkészít egy új felhasználót
app.post('/ertekeles', (req, res) => {
    const {tanuloid, tantargyid, jegy} = req.body;
    console.log(tanuloid, tantargyid, jegy);
    connection.query('INSERT INTO ertekelesek (tanuloid, tantargyid, jegy) VALUES (?, ?, ?)', [tanuloid, tantargyid, jegy], (err, results)=> {
        if(err) {
            console.log(err);
            res.send("hiba");
        }
        else {
            console.log(results);
            res.send("Sikeres felvétel!");
        }
    });
});


app.listen(port, host,() => {
  console.log(`IP: http://${host}:${port}`);
});