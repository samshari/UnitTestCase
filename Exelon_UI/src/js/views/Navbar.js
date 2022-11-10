import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import "../../styles/views/Navbar.css";
import icon from "../../images/views/engineer.png";
import hutpermittingIcon from "../../images/views/hutpermitting.webp";
import { useDispatch, useSelector } from "react-redux";
import { selectNavbarItem } from "../../redux/views/Navbar/NavbarAction";
import { DragDropContext, Droppable, Draggable } from "react-beautiful-dnd";

const Navbar = () => {
  const dispatch = useDispatch();
  const [isActive, setIsActive] = useState(1);
  const NavbarItems = [
    // {
    //   id: "0",
    //   elementName: "Admin",
    //   path: "/Admin",
    //   icon: `${icon}`,
    // },
    {
      id: "1",
      elementName: "Engineering",
      path: "/",
      icon: `${icon}`,
    },
    // // { id: "3", elementName: "Huts", path: "/Huts", icon: `${icon}` },
    // {
    //   id: "4",
    //   elementName: "Huts Execution",
    //   path: "/HutsExecution",
    //   icon: `${icon}`,
    // },
    {
      id: "5",
      elementName: "Execution Links",
      path: "/ExecutionLinks",
      icon: `${icon}`,
    },
    {
      id: "2",
      elementName: "Hut Permitting",
      path: "/HutPermitting",
      icon: `${icon}`,
    },
    // {
    //   id: "6",
    //   elementName: "Demo",
    //   path: "/Demo",
    //   icon: `${icon}`,
    // },
  ];

  const handleClick = (id) => {
    localStorage.setItem("selectedNavbarItem", id);
    dispatch(selectNavbarItem(id));
  };
  const selectedNavbarItem = useSelector(
    (state) => state.selectNavbarReducer.selectedItem
  );
  const selectedNavBarItem = localStorage.getItem("selectedNavbarItem");

  useEffect(() => {
    setIsActive(selectedNavBarItem);
  }, [selectedNavBarItem]);
  const defaultList = NavbarItems.map((item) => {
    return item;
  });
  const [navbarItems, setNavBarItems] = useState(defaultList);

  const handleDrop = (droppedItem) => {
    // Ignore drop outside droppable container
    if (!droppedItem.destination) return;
    var updatedList = [...navbarItems];
    // Remove dragged item
    const [reorderedItem] = updatedList.splice(droppedItem.source.index, 1);
    // Add dropped item
    updatedList.splice(droppedItem.destination.index, 0, reorderedItem);
    // Update State
    setNavBarItems(updatedList);
  };

  return (
    <div class="Navbar">
      <div class="scroll">
        <DragDropContext onDragEnd={handleDrop}>
          <Droppable droppableId="list-container">
            {(provided) => (
              <div
                className="list-container"
                {...provided.droppableProps}
                ref={provided.innerRef}
              >
                {navbarItems.map((item, index) => {
                  return (
                    <Draggable key={item.id} draggableId={item.id} index={index}>
                      {(provided) => (
                        <div
                          className="item-container"
                          ref={provided.innerRef}
                          {...provided.dragHandleProps}
                          {...provided.draggableProps}
                        >
                          <li
                            class={isActive === item.id && "active"}
                            onClick={() => {
                              handleClick(item.id);
                            }}
                          >
                            <Link to={item.path}>
                              <img
                                src={item.icon}
                                alt="icon"
                                width={15}
                                height={15}
                              />
                              <span>{item.elementName}</span>
                            </Link>
                          </li>
                        </div>
                      )}
                    </Draggable>
                  );
                })}
                {provided.placeholder}
              </div>
            )}
          </Droppable>
        </DragDropContext>
      </div>
    </div>
  );
};

export default Navbar;
