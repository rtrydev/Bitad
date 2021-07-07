import { HashLink } from "react-router-hash-link";
import { parseClassName, parsePicture } from "../../hooks/custom-functions";
import styles from "./Entry.module.css";
import layout from "../../assets/css/Layout.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function Entry(props) {
  return (
    <HashLink
      to={props.to}
      style={props.style}
      className={`${parseClassName(props.className)} ${styles.entry}`}
      scroll={(e) => {
        e.scrollIntoView();
        e.classList.add(bg.highlight);
        setTimeout(() => e.classList.remove(bg.highlight), 4000);
      }}
    >
      {props.showImage && (
        <img
          src={parsePicture(props.imageSrc)}
          alt={props.imageAlt}
          className={layout["image--circle"]}
        />
      )}
    </HashLink>
  );
}

export default Entry;
