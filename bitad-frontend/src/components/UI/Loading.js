import styles from "./Loading.module.css";

function Loading(props) {
  return (
    <div className={styles.loading}>
      <span
        className={styles.loading__animation}
        style={{ fontSize: props.fontSize }}
      >
        ...
      </span>
    </div>
  );
}

export default Loading;
