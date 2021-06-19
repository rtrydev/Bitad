import styles from "./Container.module.css";

function Container(props) {
  const classes = props.className !== undefined ? props.className : "";
  return (
    <div className={`${styles.container} ${classes}`}>
      <div className={styles.container__wrapper}>{props.children}</div>
    </div>
  );
}

export default Container;
