import {Link, useParams} from 'react-router-dom'

function Details() {
    const {id} = useParams()
    return (
    <>
    <p><Link to="/">Back to Home</Link></p>
   
    <div>Details Page for ID:{id}</div>

    <p>Comming Soon...</p>

    <p></p>
     <p><Link to={`/purchases/${id}`}>Buy a Ticket</Link></p>
    </>
)
}

export default Details