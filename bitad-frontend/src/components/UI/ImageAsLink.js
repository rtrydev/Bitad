import { Link } from "react-router-dom";
import styles from "./ImageAsLink.module.css";

function ImageAsLink(props) {
  const img = (
    <img
      src={props.src}
      alt={props.alt}
      className={styles.image}
      height={props.height}
    />
  );
  const internalLink = (
    <Link to={props.to ? props.to : "/"} onClick={props.onClick}>
      {img}
    </Link>
  );
  const externalLink = (
    <a href={props.to} onClick={props.onClick} target="_blank" rel="noreferrer">
      {img}
    </a>
  );

  return props.isExternalLink ? externalLink : internalLink;
}

export default ImageAsLink;
