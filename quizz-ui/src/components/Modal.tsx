import { ReactNode, useEffect, useRef } from "react";
import { useSearchParams } from "react-router-dom";
// import { useSearchParams } from "react-router-dom";

type Props = {
  title: string;
  children: ReactNode;
  onSubmit: () => void;
};

const Modal = (props: Props) => {
  const { title, children, onSubmit } = props;

  const [searchParams, setSearchParams] = useSearchParams();
  const dialogRef = useRef<null | HTMLDialogElement>(null);

  useEffect(() => {
    searchParams.get("showModal") === "y"
      ? dialogRef.current?.showModal()
      : dialogRef.current?.close();
  }, [searchParams]);

  const handleClose = () => {
    // dialogRef.current?.close();
    searchParams.delete("showModal");
    searchParams.delete("mode");
    setSearchParams(searchParams);
  };

  return (
    <dialog id="my_modal_3" className="modal" ref={dialogRef}>
      <form className="modal-box" onSubmit={onSubmit}>
        <button
          type="button"
          className="btn btn-sm btn-circle btn-ghost absolute right-2 top-2"
          onClick={handleClose}
        >
          ✕
        </button>
        <h3 className="font-bold text-lg">{title}</h3>
        {children}
      </form>
    </dialog>
  );
};

export default Modal;
