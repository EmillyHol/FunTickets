import {Link} from 'react-router-dom'

function PhotoCard(props) {
    return (
        <div className="photo-grid-item">
                <Link to={`/details/${props.ActiviteId}`}>
                <img src={props.ImageFilename} alt={props.ActivitesTitle} className="img-fluid"/>
                <div className="label">{props.ActivitesTitle}</div>
                </Link>
        </div>
    )
}
export default PhotoCard