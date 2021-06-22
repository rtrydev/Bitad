import styles from "./Loading.module.css";

function Loading(props) {
  return (
    <span className={styles.loading} style={{ fontSize: props.fontSize }}>
      ...
    </span>
  );
}

export default Loading;
