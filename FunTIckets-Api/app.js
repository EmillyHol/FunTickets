// ctrl c to exit
import express from 'express';
import  router from './routes.js';

const port = process.env.PORT || 3000;
const app = express();

//Middleware
app.use(express.json());
app.use(express.urlencoded({ extended: true }));
app.use(express.static('public'));

app.use('/api/Activites', router);

app.get('/', (req, res) => {
  res.send('Hello Express!');
});

//Start Server
app.listen(port, () => {
  console.log(`Example app listening on port ${port}`);
});