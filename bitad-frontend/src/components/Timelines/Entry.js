import { HashLink } from "react-router-hash-link";
import { parseClassName } from "../../hooks/custom-functions";
import styles from "./Entry.module.css";
import defaultPicture from "../../assets/images/default-picture.svg";

function Entry(props) {
  const src = props.imageSrc === "" ? defaultPicture : props.imageSrc;

  return (
    <HashLink
      to={props.to}
      style={props.style}
      className={`${parseClassName(props.className)} ${styles.entry}`}
    >
      {props.showImage && (
        <img src={src} alt={props.imageAlt} className={styles.entry__image} />
      )}
    </HashLink>
  );
}

export default Entry;
