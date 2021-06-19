import styles from "./DecoratedImage.module.css";

function DecoratedImage(props) {
  return (
    <div className={styles["decorated-image"]}>
      <img
        src={props.src}
        alt={props.alt}
        className={styles["decorated-image__image"]}
      />
    </div>
  );
}

export default DecoratedImage;
