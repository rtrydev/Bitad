import styles from "./Container.module.css";

function Container(props) {
  return (
    <div className={`${styles.container} ${props.className}`}>
      <div className={styles.container__wrapper}>{props.children}</div>
    </div>
  );
}

export default Container;
