import { useState, useEffect } from "react";
import styles from "./HideOnScroll.module.css";

function HideOnScroll(props) {
  const [isScrollingUp, setIsScrollingUp] = useState(0);
  const [lastScrollPosition, setLastScrollPosition] = useState(false);

  // https://stackoverflow.com/questions/57453141/using-react-hooks-to-update-w-scroll
  useEffect(() => {
    const handleScroll = (e) => {
      const scrollPosition = e.target.documentElement.scrollTop;

      if (scrollPosition < 100) return;
      setLastScrollPosition(scrollPosition);
      setIsScrollingUp(scrollPosition > lastScrollPosition);
    };

    window.addEventListener("scroll", handleScroll);

    // Clean on unmount
    return () => window.removeEventListener("scroll", handleScroll);
  }, [lastScrollPosition]);

  const scrollClass = isScrollingUp ? styles["hide-on-scroll--hide"] : "";

  return (
    <div
      className={`${styles["hide-on-scroll"]} ${scrollClass} ${props.className}`}
    >
      {props.children}
    </div>
  );
}

export default HideOnScroll;
