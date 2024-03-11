const mysql= require('mysql');
const express= require('express');

const app= express();
app.use(express.json());

let port=3000;
let host='localhost';

const connection = mysql.createConnection({
    host:host,
    user:'root',
    password: '',
    database: 'konyvtar'
});

app.get('/konyvek', (req, res)=>{
    connection.query('SELECT * FROM konyv', (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send(results);
        }
    });
});

app.put('/konyvek', (req, res)=>{
    const {konyv_id, szerzo, cim, kiadas_eve, ar, ISBN} =req.body;
    connection.query('UPDATE konyv SET szerzo = ?, cim = ?, kiadas_eve = ?, ar = ?, ISBN = ? WHERE konyv_id=?',[szerzo, cim, kiadas_eve, ar, ISBN, konyv_id], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log("Sikeres adatmódosítás");
            res.send("Sikeres adatmódosítás");
        }
    });
});

app.get('/kolcsonzesek', (req, res)=>{
    connection.query('SELECT * FROM kolcsonzes', (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send(results);
        }
    });
});



app.post('/kolcsonzesek', (req, res)=>{
    const{konyv_id, kolcsonzo_id, kivitel_datum, peldanyszam}= req.body;
    connection.query('INSERT INTO kolcsonzes (konyv_id ,kolcsonzo_id, kivitel_datum, peldanyszam) VALUES (?,?, ?, ?)',[konyv_id, kolcsonzo_id, kivitel_datum, peldanyszam], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log("kölcsönzés rögzítve");
            res.send("kölcsönzés rögzítve");
        }
    });
});

app.get('/kolcsonzok', (req, res)=>{
    connection.query('SELECT * FROM kolcsonzo', (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log(results);
            res.send(results);
        }
    });
});

app.post('/kolcsonzok', (req, res)=>{
    const {nev }=req.body;
    connection.query('INSERT INTO kolcsonzo (kolcsonzo_id, nev) VALUES (NULL, ?)',[nev], (err, results)=>{
        if(err){
            console.log(err);
            res.send("hiba");
        }else{
            console.log("sikeresn rögzítve");
            res.send("sikeresn rögzítve");
        }
    });
});


app.listen(port,()=>{
    console.log(`ip: http://${host}:${port}`);
});