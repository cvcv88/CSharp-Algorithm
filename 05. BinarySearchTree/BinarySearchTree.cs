using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructure
{
	public class BinarySearchTree<T> where T : IComparable<T> // 비교가 가능해야만 한다. 자료형 제약
	{
		private Node<T> root;

		public BinarySearchTree()
		{
			this.root = null;
		}

		public bool Add(T item)
		{
			Node<T> newNode = new Node<T>(item, null, null, null); // 부모 왼쪽 오른쪽 없는 상태

			if (root == null)
			{
				root = newNode;
				return true; // 루트 노드가 된다.
			}

			Node<T> current = root; // 현재 비교하고 있는 노드
			while (current != null)
			{
				if (item.CompareTo(current.item) < 0)
				{
					// 왼쪽으로 가는 경우
					if (current.left != null)
					{
						// 왼쪽 자식이 있는 경우
						// 왼쪽으로 가서 계속 하강작업을 반복
						current = current.left;
					}
					else
					{
						// 왼쪽 자식이 없는 경우
						// 이 자리가 추가될 자리
						current.left = newNode;
						newNode.parent = current;
						break;
					}
				}
				else if (item.CompareTo(current.item) > 0)
				{
					// 오른쪽 가는 경우
					if (current.right != null)
					{
						// 오른쪽 자식 있는 경우
						// 오른쪽으로 가서 계속 하강작업을 반복
						current = current.right;
					}
					else
					{
						// 오른쪽 자식이 없는 경우
						// 이 자리가 추가될 자리
						current.right = newNode;
						newNode.parent = current;
						break;
					}
				}
				else // if (item.CompareTo(current.item) == 0)
				{
					// 똑같은 값을 찾았을 경우
					// 중복 무시
					return false;
				}
			}
			return true;
		}
		public bool Remove(T item)
		{
			Node<T> findNode = FindNode(item);
			if (findNode != null)
			{
				EraseNode(findNode);
				return true;
			}
			else
			{
				return false;
			}
		}
		public bool Contains(T item)
		{
			Node<T> findNode = FindNode(item);
			if (findNode != null)
				return false;
			else
				return true;
			// return findNode != null ? true : false;
		}
		public void Clear()
		{
			root = null;
		}
		private Node<T> FindNode(T item)
		{
			if (root == null)
				return null;

			Node<T> current = root;
			while (current != null) // 현재 노드가 null이 아닐때까지
			{
				if (item.CompareTo(current.item) < 0)
				{
					// 왼쪽으로 가는 경우
					current = current.left;
				}
				else if (item.CompareTo(current.item) > 0)
				{
					// 오른쪽으로 가는 경우
					current = current.right;
				}
				else // if (item.CompareTo(current.item) == 0)
				{
					// 똑같은 것을 발견한 경우
					// 찾았다. 목적 달성
					return current;
				}
			}
			return null;
		}
		private void EraseNode(Node<T> node)
		{
			if (node.HasNoChild) // 자식이 하나도 없을 때, 0개인 경우
			{
				if (node.IsLeftChild)
					node.parent.left = null;
				else if (node.IsRightChild)
					node.parent.right = null;
				else // (node.IsRootNode)
					root = null;
			}
			else if (node.HasLeftChild || node.HasRightChild) // 자식이 하나 있을 때, 1개인 경우
			{
				Node<T> parent = node.parent;
				Node<T> child = node.HasLeftChild ? node.left : node.right;

				// 부모와 자식을 연결해주고 삭제
				if (node.IsLeftChild)
				{
					parent.left = child;
					child.parent = parent;
				}
				else if (node.IsRightChild)
				{
					parent.right = child;
					child.parent = parent;
				}
				else // if (node.IsRootNode)
				{
					root = child;
					child.parent = null;
				}
			}
			else // if (node.HasBothChild) // 자식이 둘다 있는 경우, 2개인 경우
			{
				Node<T> nextNode = node.right;
				while (nextNode.left != null)
				{
					nextNode = nextNode.left;
				}
				node.item = nextNode.item;
				EraseNode(nextNode);
			}
		}

	}

	public class Node<T>
	{
		public T item;

		public Node<T> parent;
		public Node<T> left;
		public Node<T> right;

		public Node(T item, Node<T> parent, Node<T> left, Node<T> right)
		{
			this.item = item;
			this.parent = parent;
			this.left = left;
			this.right = right;
		}


		public bool IsRootNode { get { return parent == null; } }
		public bool IsLeftChild { get { return parent != null && parent.left == this; } }
		public bool IsRightChild { get { return parent != null && parent.right == this; } }

		public bool HasNoChild { get { return left == null && right == null; } }
		public bool HasLeftChild { get { return left != null && right == null; } }
		public bool HasRightChild { get { return left == null && right != null; } }
		public bool HasBothChild { get { return left != null && right != null; } }
	}

}
