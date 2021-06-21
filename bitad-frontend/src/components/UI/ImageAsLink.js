import { Link } from "react-router-dom";
import styles from "./ImageAsLink.module.css";

function ImageAsLink(props) {
  return (
    <Link to={props.to}>
      <img src={props.src} alt={props.alt} className={styles.image} />
    </Link>
  );
}

export default ImageAsLink;
