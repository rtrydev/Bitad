import styles from "./ImageWithShadow.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function ImageWithShadow(props) {
  const classes = props.className !== undefined ? props.className : "";
  return (
    <img
      src={props.src}
      alt={props.alt}
      width={props.width}
      className={`${styles.image} ${bg.shadow} ${classes}`}
      style={{ maxWidth: props.maxWidth }}
    />
  );
}

export default ImageWithShadow;
