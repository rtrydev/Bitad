import classes from "./Hamburger.module.css";

function Hamburger(props) {
  const handleClick = () => {
    props.onClick();
  };

  return (
    <button
      className={`${classes.hamburger} ${
        props.isOpen ? classes["hamburger--open"] : ""
      }`}
      onClick={handleClick}
    >
      <div className={classes.hamburger__bar}></div>
      <div className={classes.hamburger__bar}></div>
      <div className={classes.hamburger__bar}></div>
    </button>
  );
}

export default Hamburger;
