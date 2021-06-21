import styles from "./DecoratedImage.module.css";
import ImageWithShadow from "./ImageWithShadow";

function DecoratedImage(props) {
  return (
    <div className={styles["decorated-image"]}>
      <ImageWithShadow src={props.src} alt={props.alt} />
    </div>
  );
}

export default DecoratedImage;
