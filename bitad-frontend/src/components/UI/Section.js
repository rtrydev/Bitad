import Container from "./Container";
import styles from "./Section.module.css";

function Section(props) {
  const section = (
    <Container className={styles.section__wrapper}>{props.children}</Container>
  );

  const smallSection = (
    <Container className={styles["section__wrapper--small"]}>
      {props.children}
    </Container>
  );

  return (
    <section id={props.id} className={props.className}>
      {props.isSmallSection ? smallSection : section}
    </section>
  );
}

export default Section;
