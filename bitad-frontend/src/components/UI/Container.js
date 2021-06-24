import styles from "./Container.module.css";

function Container(props) {
  const classes = props.className !== undefined ? props.className : "";
  const classesWrapper =
    props.classNameWrapper !== undefined ? props.classNameWrapper : "";
  return (
    <div className={`${styles.container} ${classes}`}>
      <div className={`${styles.container__wrapper} ${classesWrapper}`}>
        {props.children}
      </div>
    </div>
  );
}

export default Container;
