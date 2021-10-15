import { parseClassName, parsePicture } from "../../hooks/custom-functions";
import styles from "./Entry.module.css";
import layout from "../../assets/css/Layout.module.css";

function Entry(props) {
  return (
    <div
      style={props.style}
      className={`${parseClassName(props.className)} ${styles.entry}`}
      onClick={props.onClick}
    >
      {props.showImage && (
        <img
          src={parsePicture(props.imageSrc)}
          alt={props.imageAlt}
          className={layout["image--circle"]}
        />
      )}
    </div>
  );
}

export default Entry;
