import {Link} from 'react-router-dom'

function PhotoCard(props) {
    const baseUrl = import.meta.env.VITE_Backend_URL

     const imagePath = props.ImageFilename ? `${baseUrl}/images/${props.ImageFilename}` : "/placeholder.png";
    
    return (
      <div className="photo-grid-item">
                <Link to={`/details/${props.ActiviteId}`}>
                <img src={imagePath} alt={props.ActivitesTitle} className="img-fluid"/>
                <div className="label">{props.ActivitesTitle}</div>
                </Link>
        </div>
    )
}
export default PhotoCard