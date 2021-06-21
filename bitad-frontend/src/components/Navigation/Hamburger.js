import styles from "./Hamburger.module.css";

function Hamburger(props) {
  const handleClick = () => {
    props.onClick();
  };

  return (
    <button
      className={`${styles.hamburger} ${
        props.isOpen ? styles["hamburger--open"] : ""
      }`}
      onClick={handleClick}
    >
      <div className={styles.hamburger__bar}></div>
      <div className={styles.hamburger__bar}></div>
      <div className={styles.hamburger__bar}></div>
    </button>
  );
}

export default Hamburger;
