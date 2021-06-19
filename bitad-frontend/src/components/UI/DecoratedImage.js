import styles from "./DecoratedImage.module.css";
import bg from "../../assets/css/Backgrounds.module.css";

function DecoratedImage(props) {
  return (
    <div className={styles["decorated-image"]}>
      <img
        src={props.src}
        alt={props.alt}
        className={`${styles["decorated-image__image"]} ${bg.shadow}`}
      />
    </div>
  );
}

export default DecoratedImage;
