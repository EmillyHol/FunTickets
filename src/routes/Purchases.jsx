import {Link, useParams} from 'react-router-dom'
function Purchases() {
     const {id} = useParams()
    return (
        <>
    <p><Link to={`/details/${id}`}>Back to Home</Link></p>
    <div>Purchase Page for ID:{id}</div>
    </>
)
}

export default Purchases