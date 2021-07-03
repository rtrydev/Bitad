import { HashLink } from "react-router-hash-link";
import { parseClassName } from "../../hooks/custom-functions";
import styles from "./Entry.module.css";
import layout from "../../assets/css/Layout.module.css";
import bg from "../../assets/css/Backgrounds.module.css";
import defaultPicture from "../../assets/images/default-picture.svg";

function Entry(props) {
  const src = props.imageSrc === "" ? defaultPicture : props.imageSrc;

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
          src={src}
          alt={props.imageAlt}
          className={layout["image--circle"]}
        />
      )}
    </HashLink>
  );
}

export default Entry;
